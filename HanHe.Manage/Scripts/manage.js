// JavaScript Document
$(function(){
	
	//height	
	var wHeight=$(window).height();
	var stateHeight=$("#box_left_state").height();
	var leftHeight=$(window).height()-stateHeight -157+77; 	
	$("#box_left_menu .box_main").height(leftHeight);
	var rHeight=$(window).height()-92-24-13-20+77;
	$(".main_right .t_main").height(rHeight);
	$(".main_iframe").height(rHeight);
	
	
	//左侧导航
	$('.left_menu .one').eq(0).find("ul").slideDown();  //第一个里的ul是展开状态，或者写成<ul style="display:block">
	$('.left_menu .one h3').click(function() {
        $(this).parent().find("ul").slideToggle();
	});

	//#box_left_state .f_btn	
		$("#box_left_state .f_btn").click(function () {
			if($("#box_left_state .f_btn").text()==="-")
			{
				 $(this).parent().parent().find(".box_main").slideUp();
				 $(this).text("+");				 
				 var wHeight=$(window).height();
				 var stateHeight=$("#box_left_state").height();
				 var leftHeight=$(window).height()-stateHeight -157 +97 +77; 	
				 $("#box_left_menu .box_main").height(leftHeight);				 		 
				 return;
			 }	
			else if($("#box_left_state .f_btn").text()==="+")
			{
				 $(this).parent().parent().find(".box_main").slideDown();
				 $(this).text("-");					 
				 var wHeight=$(window).height();
				 var stateHeight=$("#box_left_state").height();
				 var leftHeight=$(window).height()-stateHeight -157 -97 +77;  	
				 $("#box_left_menu .box_main").height(leftHeight);	
				 return;
			 }				 
    	});	
	
})

//左侧拉开收起
var status = 1;
var Menus = new DvMenuCls;
document.onclick=Menus.Clear;
function switchSysBar(){
     if (1 == window.status){
		  window.status = 0;
          switchPoint.innerHTML = '<img src="../Content/Image/left.gif">';
          document.all("frmTitle").style.display="none"
     }
     else{
		  window.status = 1;
		  switchPoint.innerHTML = '<img src="../Content/Image/right.gif">';
          document.all("frmTitle").style.display=""
     }
}
