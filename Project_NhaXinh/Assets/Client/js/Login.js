const firebaseConfig = {
    apiKey: "AIzaSyA1zs6YvAU9qStE9h5yRf0h_iM9VOIUqM4",
    authDomain: "otpnhaxinh.firebaseapp.com",
    projectId: "otpnhaxinh",
    storageBucket: "otpnhaxinh.appspot.com",
    messagingSenderId: "821260390931",
    appId: "1:821260390931:web:e57e99a7fdbcfcd1f8a5e6",
    measurementId: "G-FCN1CTGHJN"
};
firebase.initializeApp(firebaseConfig);
render();

function render() {
    window.recaptcharVetifier = new firebase.auth.RecaptchaVerifier('recaptcha-container');
    recaptcharVetifier.render();
};


function LoginP() {
    event.preventDefault();
    var cus = {
        user: document.getElementById('us').value,
        password: document.getElementById('pas').value
    }
    $.ajax({
        url: '/Customer/LoginP',
        type: 'post',
        data: 'json',
        data: { model: JSON.stringify(cus) }
    }).success(function (res) {
        if (res.mslg == true) {
            if (document.getElementById("remember").checked == true) {
                alert($("#remember").checked)
                document.cookie = "User=" + cus.user +"; path=/";
            }
            window.location.href = '/Home/Index';
        }
        else {
            $("#error").click(function () {
                $.toast({
                    heading: 'Error',
                    text: 'Tài khoản đăng nhập sai',
                    icon: 'error',
                    loader: true,
                    loaderBg: '#fff',
                    showHideTransition: 'plain',
                    hideAfter: 5000,
                    position: {
                        right: 5,
                        top: 30
                    }
                })
            })
            $("#error").click();
        }
    })
}




var data = {};
var login = {
    
    addCus: function () {
        $.ajax({
            url: "/Customer/Register",
            type: 'POST',
            dataType: "json",
            data: {
                model: JSON.stringify(data)
            }, success: function (res) {
                alert(res.ms)
                if (res.ms == true) {
                    $("#success").click(function () {
                        $.toast({
                            heading: 'Success',
                            text: 'Đăng ký thành công',
                            icon: 'success',
                            loader: true,
                            loaderBg: '#fff',
                            showHideTransition: 'fade',
                            hideAfter: 5000,
                            allowToastClose: false,
                            position: {
                                right: 5,
                                top: 30
                            }
                        })
                    })
                    $("#reset").click();
                    $("#success").click();
                    document.getElementById("verify").style.display = 'none';

                }
            }
        })
    },

    ExamEmail: function () {
        event.preventDefault();
        data.CusAddress = document.getElementById('occupation').value;
        data.CusName = document.getElementById('name').value;
        data.CusPhone = document.getElementById('phone').value;
        data.CusEmail = document.getElementById('email').value;
        data.UserName = document.getElementById('username').value;
        data.Password = document.getElementById('password1').value;
        data.Brithday = document.getElementById('date').value
        $.ajax({
            url: "/Customer/ExamEmail",
            type: 'POST',
            dataType: "json",
            data: {
                email: data.CusEmail
            }, success: function (res) {
                if (res.mse == true) {
                    $.ajax({
                        url: "/Customer/ExamADT",
                        type: 'POST',
                        dataType: "json",
                        data: {
                            sdt: data.CusPhone
                        }, success: function (res) {
                            if (res.msdt == true) {
                                $.ajax({
                                    url: "/Customer/ExamUserName",
                                    type: 'POST',
                                    dataType: "json",
                                    data: {
                                        username: data.UserName
                                    }, success: function (res) {
                                        if (res.msn == true) {
                                            phoneAuth();
                                        }
                                        else {
                                            $("#error").click(function () {
                                                $.toast({
                                                    heading: 'Error',
                                                    text: 'UserName đã tồn tại',
                                                    icon: 'error',
                                                    loader: true,
                                                    loaderBg: '#fff',
                                                    showHideTransition: 'plain',
                                                    hideAfter: 5000,
                                                    position: {
                                                        right: 5,
                                                        top: 30
                                                    }
                                                })
                                            })
                                            $("#error").click();

                                        }
                                    }
                                })
                            }
                            else {
                                $("#error").click(function () {
                                    $.toast({
                                        heading: 'Error',
                                        text: 'Số điện thoại đã tồn tại',
                                        icon: 'error',
                                        loader: true,
                                        loaderBg: '#fff',
                                        showHideTransition: 'plain',
                                        hideAfter: 5000,
                                        position: {
                                            right: 5,
                                            top: 30
                                        }
                                    })
                                })
                                $("#error").click();
                                
                            }
                        }
                    })
                }
                else {
                    $("#error").click(function () {
                        $.toast({
                            heading: 'Error',
                            text: 'Email đã tồn tại',
                            icon: 'error',
                            loaderBg: '#fff',
                            hideAfter: 5000,
                            showHideTransition: 'plain',
                            position: {
                                right: 5,
                                top: 30
                            }
                        })
                    })
                    $("#error").click();

                }
            }
        })

    },
   
}


// For Firebase JS SDK v7.20.0 and later, measurementId is optional



function phoneAuth() {

    var a = document.getElementById('phone').value;
    var b = "+84";
    var number = b + a.slice(-9);
    firebase.auth().signInWithPhoneNumber(number, window.recaptcharVetifier).then(function (confirmationResult) {
        window.confirmationResult = confirmationResult;
        coderesult = confirmationResult;
        alert("Đã gửi mã thành công")
        document.getElementById("verify").style.display = 'flex';
    }).catch(function (error) {
        alert(error.message);
    });
};

function codeverity() {
    var code = document.getElementById('verificationcode').value;
    coderesult.confirm(code).then(function () {
        login.addCus();
    }).catch(function () {
        alert("nhap ma sai")
    })
}



