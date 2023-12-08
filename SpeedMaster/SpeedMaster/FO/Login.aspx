<%@ Page Title="" Language="C#" MasterPageFile="~/FO/FOMaster.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="SpeedMaster.FO.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <link rel="stylesheet" runat="server" href="/FO/css/login.css" />

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <!-- Pills navs -->
    <div class="container">
    <div style="height: 70%; width: 35%; margin-top: 20px; margin-bottom: 50px;" class="LoginDiv centerDiv">
        <ul class="nav nav-pills nav-justified mb-3" id="ex1" role="tablist">
            <li style="padding: 15px;" class="nav-item" role="presentation">
                <a style="background-color: rgb(207,32,47);" class="nav-link active" id="tab-login" data-mdb-toggle="pill" href="#pills-login" role="tab"
                    aria-controls="pills-login" aria-selected="true">Login</a>
            </li>
            <li style="padding: 15px;" class="nav-item" role="presentation">
                <a class="nav-link" id="tab-register" data-mdb-toggle="pill" href="SignUp.aspx" role="tab"
                    aria-controls="pills-register" aria-selected="false">Register</a>
            </li>
        </ul>
        <!-- Pills navs -->

        <!-- Pills content -->
        <div style="" class="tab-content LoginDiv">
            <div style="padding: 15px;" class="tab-pane fade show active" id="pills-login" role="tabpanel" aria-labelledby="tab-login">
                <div>
                    <div class="text-center mb-3">
                        <p>Sign in with:</p>

                        <button type="button" class="btn btn-link btn-floating mx-1">
                            <i class="fab fa-google"></i>
                        </button>
                    </div>

                    <p class="text-center">or:</p>

                    <!-- Email input -->
                    <div class="form-outline mb-4">
                        <asp:TextBox ID="tb_email" runat="server" class="form-control"></asp:TextBox>                        
                        <label class="form-label" for="loginName">Email or username</label>
                    </div>

                    <!-- Password input -->
                    <div class="form-outline mb-4">
                        <asp:TextBox ID="tb_password" runat="server" class="form-control"></asp:TextBox>                 
                        <label class="form-label" for="loginPassword">Password</label>
                    </div>

                    <!-- 2 column grid layout -->
                    <div class="row mb-4">
                        <div class="col-md-6 d-flex justify-content-center">
                            <!-- Checkbox -->
                            <div class="form-check mb-3 mb-md-0">
                                <input class="form-check-input" type="checkbox" value="" id="loginCheck" checked />
                                <label class="form-check-label" for="loginCheck">Remember me </label>
                            </div>
                        </div>

                        <div class="col-md-6 d-flex justify-content-center">
                            <!-- Simple link -->
                            <a href="#!">Forgot password?</a>
                        </div>
                    </div>

                    <!-- Submit button -->
                    <div style="height: 40px; position: relative;"
                        class="container">
                        <div style="margin: 0; position: absolute; top: 25%; left: 50%; -ms-transform: translate(-50%, -50%); transform: translate(-50%, -50%);"
                            class="center">
                            <asp:Button ID="btn_signin" runat="server" Text="Sign in" class="btn btn-primary" OnClick="btn_signin_Click1"/>
                           
                        </div>
                    </div>
                    <!-- Register buttons -->
                    <div class="text-center">
                        <p>Not a member? <a href="#!">Register</a></p>
                    </div>
                </div>
            </div>
            <div class="tab-pane fade" id="pills-register" role="tabpanel" aria-labelledby="tab-register">
                <div>
                    <div class="text-center mb-3">
                        <p>Sign up with:</p>
                        <button type="button" class="btn btn-link btn-floating mx-1">
                            <i class="fab fa-facebook-f"></i>
                        </button>

                        <button type="button" class="btn btn-link btn-floating mx-1">
                            <i class="fab fa-google"></i>
                        </button>

                        <button type="button" class="btn btn-link btn-floating mx-1">
                            <i class="fab fa-twitter"></i>
                        </button>

                        <button type="button" class="btn btn-link btn-floating mx-1">
                            <i class="fab fa-github"></i>
                        </button>
                    </div>

                    <p class="text-center">or:</p>

                    <!-- Name input -->
                    <div class="form-outline mb-4">
                        <input type="text" id="registerName" class="form-control" />
                        <label class="form-label" for="registerName">Name</label>
                    </div>

                    <!-- Username input -->
                    <div class="form-outline mb-4">
                        <input type="text" id="registerUsername" class="form-control" />
                        <label class="form-label" for="registerUsername">Username</label>
                    </div>

                    <!-- Email input -->
                    <div class="form-outline mb-4">
                        <input type="email" id="registerEmail" class="form-control" />
                        <label class="form-label" for="registerEmail">Email</label>
                    </div>

                    <!-- Password input -->
                    <div class="form-outline mb-4">
                        <input type="password" id="registerPassword" class="form-control" />
                        <label class="form-label" for="registerPassword">Password</label>
                    </div>

                    <!-- Repeat Password input -->
                    <div class="form-outline mb-4">
                        <input type="password" id="registerRepeatPassword" class="form-control" />
                        <label class="form-label" for="registerRepeatPassword">Repeat password</label>
                    </div>

                    <!-- Checkbox -->
                    <div class="form-check d-flex justify-content-center mb-4">
                        <input class="form-check-input me-2" type="checkbox" value="" id="registerCheck" checked
                            aria-describedby="registerCheckHelpText" />
                        <label class="form-check-label" for="registerCheck">
                            I have read and agree to the terms
                        </label>
                    </div>

                    <!-- Submit button -->
                    <button type="submit" class="btn btn-primary btn-block mb-3">Sign in</button>
                </div>
            </div>
        </div>
    </div>
    </div>
    <!-- Pills content -->

    <%--<asp:Button ID="Button1" runat="server" Text="Button" OnClick="Button1_Click" />--%>
</asp:Content>
