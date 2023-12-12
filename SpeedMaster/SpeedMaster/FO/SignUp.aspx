<%@ Page Title="" Language="C#" MasterPageFile="~/FO/FOMaster.Master" AutoEventWireup="true" CodeBehind="SignUp.aspx.cs" Inherits="SpeedMaster.FO.SignUp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <link rel="stylesheet" runat="server" href="/FO/css/login.css" />

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container">
        <div style="height: 60%; width: 35%; margin-top: 20px; /*margin-bottom: 50px; */" class="LoginDiv centerDiv">
            <ul class="nav nav-pills nav-justified mb-3" id="ex1" role="tablist">
                <li style="padding: 15px;" class="nav-item" role="presentation">
                    <a style="" class="nav-link " id="tab-login" data-mdb-toggle="pill" href="login.aspx" role="tab"
                        aria-controls="pills-login" aria-selected="true">Login</a>
                </li>
                <li style="padding: 15px;" class="nav-item" role="presentation">
                    <a class="nav-link active" style="background-color: rgb(207,32,47);" id="tab-register" data-mdb-toggle="pill" href="SignUp.aspx" role="tab"
                        aria-controls="pills-register" aria-selected="false">Register</a>
                </li>
            </ul>
            <!-- Pills navs -->

            <!-- Pills content -->
            <div style="margin-bottom: 90%;" class="tab-content LoginDiv">
                <div style="padding: 15px;" class="tab-pane fade show active" id="pills-login" role="tabpanel" aria-labelledby="tab-login">
                    <div>
                        <!-- Email input -->
                        <div class="form-outline mb-4">
                            <asp:TextBox ID="tb_email" runat="server" class="form-control" ></asp:TextBox>                      
                            <label class="form-label" for="loginEmail">Email</label>
                        </div>

                        <!-- Name input -->
                        <div class="form-outline mb-4">
                            <asp:TextBox ID="tb_name" runat="server" class="form-control"></asp:TextBox>                            
                            <label class="form-label" for="loginEmail">Name</label>
                        </div>
                        
                        <!-- Surname input -->
                        <div class="form-outline mb-4">
                            <asp:TextBox ID="tb_surname" runat="server" class="form-control"></asp:TextBox>                        
                            <label class="form-label" for="loginEmail">Surname</label>
                        </div>

                        <!-- Password input -->
                        <div class="form-outline mb-4">
                            <asp:TextBox ID="tb_password" runat="server" class="form-control" TextMode="Password"></asp:TextBox>                  
                            <label class="form-label" for="loginPassword">Password</label>
                        </div>

                        <!-- Confirm Password input -->
                        <div class="form-outline mb-4">
                            <asp:TextBox ID="tb_otherPassword" runat="server" class="form-control" TextMode="Password"></asp:TextBox>                 
                            <label class="form-label" for="loginPassword">Confirm Password</label>
                        </div>

                                                <!-- Address input -->
                        <div class="form-outline mb-4">
                            <asp:TextBox ID="tb_address" runat="server"  class="form-control"></asp:TextBox>
          
                            <label class="form-label" for="Address">Address</label>
                        </div>                        
                        
                        <div class="form-outline mb-4">
                            <asp:TextBox ID="tb_phone" runat="server" class="form-control" ></asp:TextBox>             
                            <label class="form-label" for="Phone Number">Phone Number</label>
                        </div>
                                                
                        <div class="form-outline mb-4">
                            <asp:TextBox ID="tb_nif" runat="server" class="form-control" ></asp:TextBox>               
                            <label class="form-label" for="nif">NIF</label>
                        </div>
                        <div class="form-outline mb-4">
                             <asp:Label ID="lbl_result" runat="server" Text="Label" Visible="false" ForeColor="red"></asp:Label>
                        </div>
                        <!-- 2 column grid layout -->
                        <div class="row mb-4">
                            <div class="col-md-6 d-flex justify-content-center">
                                <!-- Checkbox -->
                            </div>
                        </div>

                        <!-- Submit button -->
                        <div style="height: 40px; position: relative;"
                            class="container">
                            <div style="margin: 0; position: absolute; top: 25%; left: 50%; -ms-transform: translate(-50%, -50%); transform: translate(-50%, -50%);"
                                class="center">
                                 <asp:Button ID="Button2" runat="server" Text="Register" OnClick="Button1_Click" class="btn btn-primary" />
                               
                        
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
