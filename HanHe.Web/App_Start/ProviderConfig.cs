﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Description;
using System.Web.Mvc;

namespace HanHe.Web
{
    /// <summary>
    /// 与MultipartFormDataStreamProvider对应,但不将文件直接存入指定位置，而是需要自己指定数据流如何保存
    /// </summary>
    public class MultipartFormDataMemoryStreamProvider : MultipartStreamProvider
    {
        private NameValueCollection _formData = new NameValueCollection();
        private Collection<bool> _isFormData = new Collection<bool>();
        /// <summary>
        /// 获取文件对应的HttpContent集合,文件如何读取由实际使用方确定，可以ReadAsByteArrayAsync，也可以ReadAsStreamAsync
        /// </summary>
        public Collection<HttpContent> FileContents
        {
            get
            {
                //两者总数不一致，认为未执行过必须的Request.Content.ReadAsMultipartAsync(provider)方法
                if (this._isFormData.Count != this.Contents.Count)
                {
                    throw new InvalidOperationException("System.Net.Http.HttpContentMultipartExtensions.ReadAsMultipartAsync must be called first!");
                }
                return new Collection<HttpContent>(this.Contents.Where((ct, idx) => !this._isFormData[idx]).ToList());
            }
        }
        /// <summary>Gets a <see cref="T:System.Collections.Specialized.NameValueCollection" /> of form data passed as part of the multipart form data.</summary>
        /// <returns>The <see cref="T:System.Collections.Specialized.NameValueCollection" /> of form data.</returns>
        public NameValueCollection FormData
        {
            get
            {
                return this._formData;
            }
        }
        public override async Task ExecutePostProcessingAsync()
        {
            for (var i = 0; i < this.Contents.Count; i++)
            {
                //非文件
                if (!this._isFormData[i])
                {
                    continue;
                }
                var formContent = this.Contents[i];
                ContentDispositionHeaderValue contentDisposition = formContent.Headers.ContentDisposition;
                string formFieldName = UnquoteToken(contentDisposition.Name) ?? string.Empty;
                string formFieldValue = await formContent.ReadAsStringAsync();
                this.FormData.Add(formFieldName, formFieldValue);
            }
        }
        public override Stream GetStream(HttpContent parent, HttpContentHeaders headers)
        {
            if (parent == null)
            {
                throw new ArgumentNullException("parent");
            }
            if (headers == null)
            {
                throw new ArgumentNullException("headers");
            }
            ContentDispositionHeaderValue contentDisposition = headers.ContentDisposition;
            if (contentDisposition == null)
            {
                throw new InvalidOperationException("Content-Disposition is null");
            }
            this._isFormData.Add(string.IsNullOrEmpty(contentDisposition.FileName));
            return new MemoryStream();
        }
        /// <summary>
        /// 复制自 System.Net.Http.FormattingUtilities 下同名方法，因为该类为internal，不能在其它命名空间下被调用
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        private static string UnquoteToken(string token)
        {
            if (string.IsNullOrWhiteSpace(token))
            {
                return token;
            }
            if (token.StartsWith("\"", StringComparison.Ordinal) && token.EndsWith("\"", StringComparison.Ordinal) && token.Length > 1)
            {
                return token.Substring(1, token.Length - 2);
            }
            return token;
        }
    }

    public class MultipartFileWithExtensionStreamProvider : MultipartFileStreamProvider
    {
        // 摘要: 
        //     初始化 System.Net.Http.MultipartFileStreamProvider 类的新实例。
        //
        // 参数: 
        //   rootPath:
        //     MIME 多部分正文部分的内容写入到的根路径。
        public MultipartFileWithExtensionStreamProvider(string rootPath)
            : this(rootPath, 4096)
        {
        }
        //
        // 摘要: 
        //     初始化 System.Net.Http.MultipartFileStreamProvider 类的新实例。
        //
        // 参数: 
        //   rootPath:
        //     MIME 多部分正文部分的内容写入到的根路径。
        //
        //   bufferSize:
        //     为写入到文件而缓冲的字节数。
        public MultipartFileWithExtensionStreamProvider(string rootPath, int bufferSize)
            : base(rootPath, bufferSize)
        {
        }
        public override string GetLocalFileName(HttpContentHeaders headers)
        {
            return base.GetLocalFileName(headers) + Path.GetExtension(headers.ContentDisposition.FileName);
        }
    }
}