<%@ Page Title="" Language="C#" MasterPageFile="~/FO/FOMaster.Master" AutoEventWireup="true" CodeBehind="ResetPassword.aspx.cs" Inherits="SpeedMaster.FO.ResetPassword" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <link rel="stylesheet" runat="server" href="/FO/css/login.css" />

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container">
        <div style="height: 60%; width: 35%; margin-top: 20px;" class="LoginDiv centerDiv">
            <!-- Pills navs -->

            <!-- Pills content -->
            <div style="" class="tab-content LoginDiv">
                <div style="padding: 15px;" class="tab-pane fade show active" id="pills-login" role="tabpanel" aria-labelledby="tab-login">
                    <div>
                        <div class="text-center mb-3">
                            <p style="font-size: 30px;">Reset Password</p>
                        </div>
                        <br />
                        <!-- Email input -->
                        <div class="form-outline mb-4">
                            <input type="email" id="loginName" class="form-control" />
                            <label class="form-label" for="loginName">Email</label>
                        </div>

                        <!-- old Password input -->
                        <div class="form-outline mb-4">
                            <input type="password" id="OldPassword" class="form-control" />
                            <label class="form-label" for="loginPassword">Old Password</label>
                        </div>

                        <!-- new Password input -->
                        <div class="form-outline mb-4">
                            <input type="password" id="NewPassword" class="form-control" />
                            <label class="form-label" for="loginPassword">New Password</label>
                        </div>

                        <!-- new Password confirmation input -->
                        <div class="form-outline mb-4">
                            <input type="password" id="ConfirmNewPassword" class="form-control" />
                            <label class="form-label" for="loginPassword">Confirm New Password</label>
                        </div>

                        <!-- 2 column grid layout -->
                        <div class="row mb-4">
                            <div class="col-md-6 d-flex justify-content-center">
                            </div>
                        </div>

                        <!-- Submit button -->
                        <div style="height: 40px; position: relative;"
                            class="container">
                            <div style="margin: 0; position: absolute; top: 25%; left: 50%; -ms-transform: translate(-50%, -50%); transform: translate(-50%, -50%);"
                                class="center">
                                <button type="submit" class="btn btn-primary">Change Password</button>
                            </div>
                        </div>
                        <!-- Register buttons -->
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


</asp:Content>
