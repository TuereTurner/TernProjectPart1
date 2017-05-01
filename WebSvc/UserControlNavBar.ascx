<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UserControlNavBar.ascx.cs" Inherits="WebSvc.UserControlNavBar" %>
  <style>
 
       ul{
           list-style-type:none;
           margin-left:20px;
            padding-left: 50px;
           padding:0;
           overflow:hidden;
           background-color:black;
           position:fixed;
           top:0;
           width:100%;
            left: -20px;
            margin-right: 0;
            margin-top: 0;
            margin-bottom: 0;
        }
       li{
           float:left;
       }
       li a{
           display:block;
           color: white;
           text-align:center;
           padding:14px 16px;
           text-decoration:none;
       }
     
  </style> 


 <div>
           
             <ul>
            <li> <a href="CloudUser.aspx"> Home</a></li>
            <li> <a href="File Storage Restore.aspx"> Restore Files</a></li>
            <li> <a href="AskQuestion.aspx"> Ask Questions</a></li>
                 <li> <a href="EditUserByUser.aspx">Edit Profile</a></li>
                 <li> <a href="BuyMoreStorage.aspx"> Buy Storage</a></li>
                    <li> <a href="Registration.aspx"> Registration</a></li>
            <li style="float:right""> <a href="EditUserByUser.aspx">  <i class="fa fa-gear"></i> User Setting</a></li>
            <li style="float:right; color:cornflowerblue;"> <a href="Login.aspx" > <i class="fa fa-sign-out"></i> LogOut </a></li>
        </ul>

        </div>