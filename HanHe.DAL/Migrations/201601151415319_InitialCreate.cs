namespace HanHe.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Zs_ChuanJia",
                c => new
                    {
                        CJID = c.Long(nullable: false, identity: true),
                        MID = c.Long(nullable: false),
                        TypeID = c.Int(nullable: false),
                        CJTitle = c.String(),
                        CJTitleShort = c.String(),
                        CJInfo = c.String(),
                        OpenStatus = c.Int(nullable: false),
                        OpenStatusName = c.String(),
                        SortID = c.Int(nullable: false),
                        CreateDate = c.DateTime(nullable: false),
                        ViewCount = c.Int(nullable: false),
                        GoodCount = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CJID);
            
            CreateTable(
                "dbo.Zs_ChuanJiaAtt",
                c => new
                    {
                        AttID = c.Long(nullable: false, identity: true),
                        CJID = c.Long(nullable: false),
                        AttTitle = c.String(),
                        AttInfo = c.String(),
                        AttUrl = c.String(),
                        AttType = c.Int(nullable: false),
                        AttTypeName = c.String(),
                        SortID = c.Int(nullable: false),
                        CreateDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.AttID);
            
            CreateTable(
                "dbo.Zs_ChuanJiaComment",
                c => new
                    {
                        CommentID = c.Long(nullable: false, identity: true),
                        CJID = c.Long(nullable: false),
                        MID = c.Long(nullable: false),
                        RMID = c.Long(nullable: false),
                        CType = c.Int(nullable: false),
                        CTypeName = c.String(),
                        CInfo = c.String(),
                        CreateDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.CommentID);
            
            CreateTable(
                "dbo.Zs_Department",
                c => new
                    {
                        DepID = c.Int(nullable: false, identity: true),
                        DepName = c.String(),
                        ParentID = c.Int(nullable: false),
                        SortID = c.Int(nullable: false),
                        ManagerID = c.Int(nullable: false),
                        Remark = c.String(),
                        CreateDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.DepID);
            
            CreateTable(
                "dbo.Zs_Dic",
                c => new
                    {
                        DicID = c.Int(nullable: false, identity: true),
                        DicCode = c.String(),
                        DicName = c.String(),
                        DicNameEn = c.String(),
                        DicProperty = c.Int(nullable: false),
                        DicPropertyName = c.String(),
                        ParentID = c.Int(nullable: false),
                        SortID = c.Int(nullable: false),
                        Remark = c.String(),
                        CreateDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.DicID);
            
            CreateTable(
                "dbo.Zs_FavoritesInfo",
                c => new
                    {
                        FInfoID = c.Long(nullable: false, identity: true),
                        MID = c.Long(nullable: false),
                        FavoritesUrl = c.String(),
                        CreateDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.FInfoID);
            
            CreateTable(
                "dbo.Zs_FCAtt",
                c => new
                    {
                        AttID = c.Long(nullable: false, identity: true),
                        FCID = c.Long(nullable: false),
                        AttType = c.Int(nullable: false),
                        AttTypeName = c.String(),
                        AttTitle = c.String(),
                        AttUrl = c.String(),
                        SortID = c.Int(nullable: false),
                        CreateDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.AttID);
            
            CreateTable(
                "dbo.Zs_FCBlack",
                c => new
                    {
                        FCBlackID = c.Long(nullable: false, identity: true),
                        MID = c.Long(nullable: false),
                        BMID = c.Long(nullable: false),
                        BlackProperty = c.Int(nullable: false),
                        BlackPropertyName = c.String(),
                    })
                .PrimaryKey(t => t.FCBlackID);
            
            CreateTable(
                "dbo.Zs_FCComment",
                c => new
                    {
                        CommentID = c.Long(nullable: false, identity: true),
                        FCID = c.Long(nullable: false),
                        MID = c.Long(nullable: false),
                        RMID = c.Long(nullable: false),
                        CType = c.Int(nullable: false),
                        CTypeName = c.String(),
                        CInfo = c.String(),
                        CreateDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.CommentID);
            
            CreateTable(
                "dbo.Zs_FCircle",
                c => new
                    {
                        FCID = c.Long(nullable: false, identity: true),
                        MID = c.Long(nullable: false),
                        FCTitle = c.String(),
                        FCInfo = c.String(),
                        FCUrl = c.String(),
                        ViewCount = c.Int(nullable: false),
                        GoodCount = c.Int(nullable: false),
                        CreateDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.FCID);
            
            CreateTable(
                "dbo.Zs_FGroup",
                c => new
                    {
                        FGroupID = c.Long(nullable: false, identity: true),
                        MID = c.Long(nullable: false),
                        GroupName = c.String(),
                        SortID = c.Int(nullable: false),
                        CreateDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.FGroupID);
            
            CreateTable(
                "dbo.Zs_Friend",
                c => new
                    {
                        FriendID = c.Long(nullable: false, identity: true),
                        MID = c.Long(nullable: false),
                        FGroupID = c.Long(nullable: false),
                        FMID = c.Long(nullable: false),
                        RmarkName = c.String(),
                        QmWeight = c.Int(nullable: false),
                        JoinDate = c.DateTime(nullable: false),
                        FStatus = c.Int(nullable: false),
                        FStatusName = c.String(),
                    })
                .PrimaryKey(t => t.FriendID);
            
            CreateTable(
                "dbo.Zs_GanWu",
                c => new
                    {
                        GwID = c.Long(nullable: false, identity: true),
                        MID = c.Long(nullable: false),
                        GwTitle = c.String(),
                        GwTitleShort = c.String(),
                        GwInfo = c.String(),
                        GwType = c.Int(nullable: false),
                        GwTypeName = c.String(),
                        OpenStatus = c.Int(nullable: false),
                        OpenStatusName = c.String(),
                        GotoDate = c.DateTime(nullable: false),
                        PostDate = c.DateTime(nullable: false),
                        GwStatus = c.Int(nullable: false),
                        GwStatusName = c.String(),
                        SmsStatus = c.Int(nullable: false),
                        SmsStatusName = c.String(),
                        CreateDate = c.DateTime(nullable: false),
                        ViewCount = c.Int(nullable: false),
                        GoodCount = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.GwID);
            
            CreateTable(
                "dbo.Zs_GanWuAtt",
                c => new
                    {
                        AttID = c.Long(nullable: false, identity: true),
                        GWID = c.Long(nullable: false),
                        AttTitle = c.String(),
                        AttInfo = c.String(),
                        AttUrl = c.String(),
                        AttType = c.Int(nullable: false),
                        AttTypeName = c.String(),
                        SortID = c.Int(nullable: false),
                        CreateDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.AttID);
            
            CreateTable(
                "dbo.Zs_GanWuComment",
                c => new
                    {
                        CommentID = c.Long(nullable: false, identity: true),
                        GWID = c.Long(nullable: false),
                        MID = c.Long(nullable: false),
                        RMID = c.Long(nullable: false),
                        CType = c.Int(nullable: false),
                        CTypeName = c.String(),
                        CInfo = c.String(),
                        CreateDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.CommentID);
            
            CreateTable(
                "dbo.Zs_GuoXue",
                c => new
                    {
                        GxID = c.Long(nullable: false, identity: true),
                        Keywords = c.String(),
                        GxTitle = c.String(),
                        GxTitleShort = c.String(),
                        GxInfo = c.String(),
                        Category01 = c.Int(nullable: false),
                        Category02 = c.Int(nullable: false),
                        Category03 = c.Int(nullable: false),
                        CreateDate = c.DateTime(nullable: false),
                        UpdateDate = c.DateTime(nullable: false),
                        GxStatus = c.Int(nullable: false),
                        GxStatusName = c.String(),
                        PublishDate = c.DateTime(nullable: false),
                        ViewCount = c.Int(nullable: false),
                        GoodCount = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.GxID);
            
            CreateTable(
                "dbo.Zs_GuoXueAtt",
                c => new
                    {
                        AttID = c.Long(nullable: false, identity: true),
                        GXID = c.Long(nullable: false),
                        AttType = c.Int(nullable: false),
                        AttTypeName = c.String(),
                        AttTitle = c.String(),
                        AttUrl = c.String(),
                        SortID = c.Int(nullable: false),
                        CreateDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.AttID);
            
            CreateTable(
                "dbo.Zs_GuoXueComment",
                c => new
                    {
                        CommentID = c.Long(nullable: false, identity: true),
                        GXID = c.Long(nullable: false),
                        MID = c.Long(nullable: false),
                        RMID = c.Long(nullable: false),
                        CType = c.Int(nullable: false),
                        CTypeName = c.String(),
                        CInfo = c.String(),
                        CreateDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.CommentID);
            
            CreateTable(
                "dbo.Zs_Keywords",
                c => new
                    {
                        KwID = c.Int(nullable: false, identity: true),
                        ZsKeyWords = c.String(),
                        WeightNum = c.Int(nullable: false),
                        KwStatus = c.Int(nullable: false),
                        KwStatusName = c.String(),
                    })
                .PrimaryKey(t => t.KwID);
            
            CreateTable(
                "dbo.Zs_Member",
                c => new
                    {
                        MID = c.Long(nullable: false, identity: true),
                        MChar = c.Guid(nullable: false),
                        MCode = c.String(),
                        MName = c.String(),
                        NickName = c.String(),
                        Pwd = c.String(),
                        Sex = c.Int(nullable: false),
                        SexName = c.String(),
                        IDType = c.Int(nullable: false),
                        IDCode = c.String(),
                        BirthdayCn = c.DateTime(),
                        BirthdayEn = c.DateTime(),
                        CalendarType = c.Int(nullable: false),
                        CalendarTypeNmae = c.String(),
                        MyLife = c.Int(nullable: false),
                        Mobile = c.String(),
                        Email = c.String(),
                        QQ = c.String(),
                        WeiXin = c.String(),
                        Address = c.String(),
                        PostCode = c.String(),
                        CountryID = c.Int(nullable: false),
                        ProvinceID = c.Int(nullable: false),
                        CityID = c.Int(nullable: false),
                        AreaID = c.Int(nullable: false),
                        IconUrl = c.String(),
                        MySign = c.String(),
                        Remark = c.String(),
                        CreateDate = c.DateTime(nullable: false),
                        UpdateDate = c.DateTime(),
                        MStatus = c.Int(nullable: false),
                        MStatusName = c.String(),
                        ActDate = c.DateTime(),
                        DelStatus = c.Boolean(nullable: false),
                        DelStatusName = c.String(),
                        DelDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.MID);
            
            CreateTable(
                "dbo.Zs_MemorialDay",
                c => new
                    {
                        MDayID = c.Long(nullable: false, identity: true),
                        MID = c.Long(nullable: false),
                        FMID = c.Long(nullable: false),
                        FName = c.String(),
                        MDayTitle = c.String(),
                        MDate = c.DateTime(nullable: false),
                        CalendarType = c.Int(nullable: false),
                        CalendarTypeName = c.String(),
                        MDateEn = c.DateTime(nullable: false),
                        AdvanceDay = c.Int(nullable: false),
                        RouseDate = c.DateTime(nullable: false),
                        RouseSms = c.Int(nullable: false),
                        RouseMusic = c.String(),
                        MDayMsg = c.String(),
                        CreateDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.MDayID);
            
            CreateTable(
                "dbo.Zs_NewFriend",
                c => new
                    {
                        NFID = c.Long(nullable: false, identity: true),
                        MID = c.Long(nullable: false),
                        FMID = c.Long(nullable: false),
                        SourceID = c.Int(nullable: false),
                        NFStatus = c.Int(nullable: false),
                        NFStatusName = c.String(),
                        RefuseReason = c.String(),
                        CreateDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.NFID);
            
            CreateTable(
                "dbo.Zs_Product",
                c => new
                    {
                        ProID = c.Long(nullable: false, identity: true),
                        MID = c.Long(nullable: false),
                        Keywords = c.String(),
                        ProCode = c.String(),
                        ProName = c.String(),
                        ProProperty = c.Int(nullable: false),
                        ProPropertyName = c.String(),
                        Category01 = c.Int(nullable: false),
                        Category02 = c.Int(nullable: false),
                        Category03 = c.Int(nullable: false),
                        UnitID = c.Int(nullable: false),
                        ProStatus = c.Int(nullable: false),
                        ProStatusName = c.String(),
                        ProDesc = c.String(),
                        CreateDate = c.DateTime(nullable: false),
                        UpdateDate = c.DateTime(nullable: false),
                        ViewCount = c.Int(nullable: false),
                        FavoriteCount = c.Int(nullable: false),
                        SalesCount = c.Int(nullable: false),
                        CancelCount = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ProID);
            
            CreateTable(
                "dbo.Zs_ProductAtt",
                c => new
                    {
                        AttID = c.Long(nullable: false, identity: true),
                        ProID = c.Long(nullable: false),
                        AttType = c.Int(nullable: false),
                        AttTypeName = c.String(),
                        AttTitle = c.String(),
                        AttUrl = c.String(),
                        SortID = c.Int(nullable: false),
                        CreateDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.AttID);
            
            CreateTable(
                "dbo.Zs_Project",
                c => new
                    {
                        ProjectID = c.Long(nullable: false, identity: true),
                        MID = c.Long(nullable: false),
                        ProTitle = c.String(),
                        ProInfo = c.String(),
                        ImpropantWeight = c.Int(nullable: false),
                        UrgentWeight = c.Int(nullable: false),
                        SortID = c.Int(nullable: false),
                        StartDate = c.DateTime(nullable: false),
                        ExpectDate = c.DateTime(nullable: false),
                        ProStatus = c.Int(nullable: false),
                        ProStatusName = c.String(),
                        FinishedDate = c.DateTime(nullable: false),
                        ProgressNum = c.Int(nullable: false),
                        OpenStatus = c.Int(nullable: false),
                        OpenStatusName = c.String(),
                        CreateDate = c.DateTime(nullable: false),
                        ViewCount = c.Int(nullable: false),
                        GoodCount = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ProjectID);
            
            CreateTable(
                "dbo.Zs_ProjectAtt",
                c => new
                    {
                        AttID = c.Long(nullable: false, identity: true),
                        ProjectID = c.Long(nullable: false),
                        AttTitle = c.String(),
                        AttInfo = c.String(),
                        AttUrl = c.String(),
                        AttType = c.Int(nullable: false),
                        AttTypeName = c.String(),
                        SortID = c.Int(nullable: false),
                        CreateDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.AttID);
            
            CreateTable(
                "dbo.Zs_ProjectClock",
                c => new
                    {
                        ClockID = c.Long(nullable: false, identity: true),
                        ProjectID = c.Long(nullable: false),
                        ClockName = c.String(),
                        ClockTime = c.DateTime(nullable: false),
                        MusicUrl = c.String(),
                        SmsStatus = c.Int(nullable: false),
                        SmsStatusName = c.String(),
                    })
                .PrimaryKey(t => t.ClockID);
            
            CreateTable(
                "dbo.Zs_ProjectComment",
                c => new
                    {
                        CommentID = c.Long(nullable: false, identity: true),
                        ProjectID = c.Long(nullable: false),
                        MID = c.Long(nullable: false),
                        RMID = c.Long(nullable: false),
                        CType = c.Int(nullable: false),
                        CTypeName = c.String(),
                        CInfo = c.String(),
                        CreateDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.CommentID);
            
            CreateTable(
                "dbo.Zs_Right",
                c => new
                    {
                        RightID = c.Int(nullable: false, identity: true),
                        RightCode = c.String(),
                        RightName = c.String(),
                        ParentID = c.Int(nullable: false),
                        SortID = c.Int(nullable: false),
                        RightProperty = c.Int(nullable: false),
                        RightPropertyName = c.String(),
                        Remark = c.String(),
                        CreateDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.RightID);
            
            CreateTable(
                "dbo.Zs_Role",
                c => new
                    {
                        RoleID = c.Int(nullable: false, identity: true),
                        RoleCode = c.String(),
                        RoleName = c.String(),
                        SortID = c.Int(nullable: false),
                        RoleProperty = c.Int(nullable: false),
                        RolePropertyName = c.String(),
                        Remark = c.String(),
                        CreateDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.RoleID);
            
            CreateTable(
                "dbo.Zs_RoleUser",
                c => new
                    {
                        RUserID = c.Int(nullable: false, identity: true),
                        RoleID = c.Int(nullable: false),
                        ZsUserID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.RUserID);
            
            CreateTable(
                "dbo.Zs_SetNotice",
                c => new
                    {
                        NMNoticeID = c.Long(nullable: false, identity: true),
                        MID = c.Long(nullable: false),
                        MsgDetail = c.Int(nullable: false),
                        MsgDetailName = c.String(),
                        DisturbStatus = c.Int(nullable: false),
                        DisturbStatusName = c.String(),
                        VoiceStatus = c.Int(nullable: false),
                        VoiceStatusName = c.String(),
                        ShakeStatus = c.Int(nullable: false),
                        ShakeStatusName = c.String(),
                        FCNewStatus = c.Int(nullable: false),
                        FCNewStatusName = c.String(),
                    })
                .PrimaryKey(t => t.NMNoticeID);
            
            CreateTable(
                "dbo.Zs_SetPrivacy",
                c => new
                    {
                        PrivacyID = c.Long(nullable: false, identity: true),
                        MID = c.Long(nullable: false),
                        JoinCheck = c.Int(nullable: false),
                        RecommendQQ = c.Int(nullable: false),
                        SearchByQQ = c.Int(nullable: false),
                        SearchByMobile = c.Int(nullable: false),
                        RecommendMobile = c.Int(nullable: false),
                        SearchByZsCode = c.Int(nullable: false),
                        AllowPic = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PrivacyID);
            
            CreateTable(
                "dbo.Zs_User",
                c => new
                    {
                        ZsUserID = c.Int(nullable: false, identity: true),
                        UserNameCn = c.String(),
                        UserNameEn = c.String(),
                        LoginName = c.String(),
                        Pwd = c.String(),
                        RoleID = c.Int(nullable: false),
                        Mobile = c.String(),
                        Email = c.String(),
                        QQ = c.String(),
                        WeiXin = c.String(),
                        UserChar = c.Guid(nullable: false),
                        UserStatus = c.Int(nullable: false),
                        UserStatusName = c.String(),
                        CreateDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ZsUserID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Zs_User");
            DropTable("dbo.Zs_SetPrivacy");
            DropTable("dbo.Zs_SetNotice");
            DropTable("dbo.Zs_RoleUser");
            DropTable("dbo.Zs_Role");
            DropTable("dbo.Zs_Right");
            DropTable("dbo.Zs_ProjectComment");
            DropTable("dbo.Zs_ProjectClock");
            DropTable("dbo.Zs_ProjectAtt");
            DropTable("dbo.Zs_Project");
            DropTable("dbo.Zs_ProductAtt");
            DropTable("dbo.Zs_Product");
            DropTable("dbo.Zs_NewFriend");
            DropTable("dbo.Zs_MemorialDay");
            DropTable("dbo.Zs_Member");
            DropTable("dbo.Zs_Keywords");
            DropTable("dbo.Zs_GuoXueComment");
            DropTable("dbo.Zs_GuoXueAtt");
            DropTable("dbo.Zs_GuoXue");
            DropTable("dbo.Zs_GanWuComment");
            DropTable("dbo.Zs_GanWuAtt");
            DropTable("dbo.Zs_GanWu");
            DropTable("dbo.Zs_Friend");
            DropTable("dbo.Zs_FGroup");
            DropTable("dbo.Zs_FCircle");
            DropTable("dbo.Zs_FCComment");
            DropTable("dbo.Zs_FCBlack");
            DropTable("dbo.Zs_FCAtt");
            DropTable("dbo.Zs_FavoritesInfo");
            DropTable("dbo.Zs_Dic");
            DropTable("dbo.Zs_Department");
            DropTable("dbo.Zs_ChuanJiaComment");
            DropTable("dbo.Zs_ChuanJiaAtt");
            DropTable("dbo.Zs_ChuanJia");
        }
    }
}
