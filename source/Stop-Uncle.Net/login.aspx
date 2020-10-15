<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="login.aspx.vb" Inherits="Stop_Uncle.Net.login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <meta content="width=device-width, initial-scale=1, shrink-to-fit=no" name="viewport"/>

    <link href="https://stackpath.bootstrapcdn.com/bootstrap/4.5.2/css/bootstrap.min.css" rel="stylesheet"/>
    <link href="https://cdnjs.cloudflare.com/ajax/libs/mdbootstrap/4.19.1/css/mdb.min.css" rel="stylesheet"/>

    <title>AjeAPI - 로그인</title>
</head>
<body>
    <form id="form1" runat="server" class="form-signin">
        <h1 class="h3 mb-1 font-weight-normal text-center">AjeAPI</h1>
        <p class="mb-3 font-weight-normal text-center">관리자 패널로 로그인하기</p>

        <br />

        <label for="inputEmail" class="sr-only">사용자 이름</label>
        <input autocomplete="off" type="text" id="inputEmail" class="form-control" placeholder="유저 네임" runat="server" autofocus=""/>

        <label for="inputPassword" class="sr-only">비밀번호</label>
        <input type="password" id="inputPassword" class="form-control" runat="server" placeholder="비밀번호"/>

        <br />

        <button class="btn btn-lg btn-primary btn-block" id="btnSignIn" runat="server">로그인</button>
        <p class="mt-5 mb-3 text-muted text-center">© 2019-2020 Team Wave</p>
    </form>

    <style>
        html,
        body {
          height: 100%;
          font-family: 'Noto Sans KR', sans-serif;
        }

        body {
          display: -ms-flexbox;
          display: -webkit-box;
          display: flex;
          -ms-flex-align: center;
          -ms-flex-pack: center;
          -webkit-box-align: center;
          align-items: center;
          -webkit-box-pack: center;
          justify-content: center;
          padding-top: 40px;
          padding-bottom: 40px;
          background-color: #f5f5f5;
        }

        .form-signin {
          width: 100%;
          max-width: 330px;
          padding: 15px;
          margin: 0 auto;
        }
        .form-signin .checkbox {
          font-weight: 400;
        }
        .form-signin .form-control {
          position: relative;
          box-sizing: border-box;
          height: auto;
          padding: 10px;
          font-size: 16px;
        }
        .form-signin .form-control:focus {
          z-index: 2;
        }
        .form-signin input[type="text"] {
          margin-bottom: -1px;
          border-bottom-right-radius: 0;
          border-bottom-left-radius: 0;
        }
        .form-signin input[type="password"] {
          margin-bottom: 10px;
          border-top-left-radius: 0;
          border-top-right-radius: 0;
        }
    </style>
</body>
</html>