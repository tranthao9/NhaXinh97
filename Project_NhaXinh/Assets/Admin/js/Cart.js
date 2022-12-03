var promotion = []
var common = {
    init: function () {
        common.GetData();
        common.loadData();
        common.loadPromotion()
    },
    registerEvent: function () {

    },
    loadPromotion: function () {
        $.ajax({
            url: '/Home/getPromotion',
            dataType: 'json',
            success: function (res) {
                promotion = res.data
                console.log(promotion)
            }
        })
    },
    GetData: function () {
        $.ajax({
            url: "/Home/NewProduct",
            dataType: "json",
            success: function (res) {
                if (res.status) {
                    var newsp = res.Data;
                    var html = '';
                    var datatable = $('#addItem').html();
                    $.each(newsp, function (i, item) {
                        html += Mustache.render(datatable, {
                            Id: item.ProID,
                            ProImage: item.ProImage,
                            ProName: item.ProName,
                            Cost: (item.Cost).toLocaleString('de-DE', {
                                maximumFractionDigits: currencyFractionDigits
                            }) + 'đ ',
                            PreCost: (item.PreCost).toLocaleString('de-DE', {
                                maximumFractionDigits: currencyFractionDigits
                            }) + 'đ ',
                            Cost2: item.Cost
                        });
                    });
                    $('#newproduct').html(html);

                }
            },
        })
    },
    AddCart: function (idd, name, image, cost) {
        debugger
        var ob = idd;
        var user;
        if (sessionStorage.getItem("User") != null) {
            if (sessionStorage.getItem("User") != "") {
                user = sessionStorage.getItem("User");
                alert(user)
                $.ajax({
                    url: "/Home/AddCart",
                    dataType: "json",
                    data: { id: ob, quantity: 1, Username: user },
                    success: function () {
                        common.loadData();
                        $('.submenu_h2').show();
                    }, error: function (er) {
                        alert(er.responseText);
                    }
                });
            }
            else {
                if (getCookie("User") != "") {
                    user = getCookie("User");
                    alert(user)
                    $.ajax({
                        url: "/Home/AddCart",
                        dataType: "json",
                        data: { id: ob, quantity: 1, Username: user },
                        success: function () {
                            common.loadData();
                            $('.submenu_h2').show();

                        }, error: function (er) {
                            alert(er.responseText);
                        }
                    });
                }
                else {
                    addCartLocal(idd, name, image, cost)
                    common.loadData();
                    $('.submenu_h2').show();
                }
            }
        }
        else {
            if (getCookie("User") != "") {
                user = getCookie("User");
                alert(user)
                $.ajax({
                    url: "/Home/AddCart",
                    dataType: "json",
                    data: { id: ob, quantity: 1, Username: user },
                    success: function () {
                        common.loadData();
                        $('.submenu_h2').show();

                    }, error: function (er) {
                        alert(er.responseText);
                    }
                });
            }
            else {
                addCartLocal(idd, name, image, cost)
                common.loadData();
                $('.submenu_h2').show();
            }
        }

    },
    loadData: function () {
        if (sessionStorage.getItem("User") != null) {
            if (sessionStorage.getItem("User") != "") {
                LoadCartSQL(sessionStorage.getItem("User"))
            }
            else {
                if (getCookie("User") != "") {
                    LoadCartSQL(getCookie("User"))
                }
                else {
                    LoadCartLocal()
                }
            }
        }
        else {
            if (getCookie("User") != "") {
                LoadCartSQL(getCookie("User"))
            }
            else {
                LoadCartLocal();
            }
        }

    },
    updateCart: function (idd) {
        var data = {
            ProID: idd,
            Quantity: document.getElementById(idd).value
        };
        if (sessionStorage.getItem("User") != null) {
            if (sessionStorage.getItem("User") != "") {
                UpdateCartSql(data, sessionStorage.getItem("User"))
            }
            else {
                if (getCookie("User") != "") {
                    UpdateCartSql(data, getCookie("User"))
                }
                else {
                    UpdateCartLocal(data.ProID, data.Quantity)
                }
            }
        }
        else {
            if (getCookie("User") != "") {
                UpdateCartSql(data, getCookie("User"))
            }
            else {
                UpdateCartLocal(data.ProID, data.Quantity)
            }
        }

    },
    removeCart: function (s) {
        var ob = s;
        if (sessionStorage.getItem("User") != null) {
            if (sessionStorage.getItem("User") != "") {
                RemoveCartSQL(ob, sessionStorage.getItem("User"))
            }
            else {
                if (getCookie("User") != "") {
                    RemoveCartSQL(ob, getCookie("User"))
                }
                else {
                    RemoveCartLocal(ob)
                }
            }
        }
        else {
            if (getCookie("User") != "") {
                RemoveCartSQL(ob, getCookie("User"))
            }
            else {
                RemoveCartLocal(ob)
            }
        }
    }

}
common.init();
function Checkout() {
    if ($("#Dangnhap").html() == "Đăng nhập") {
        $("#closeCart").click();
        $("#Singin").click();
    }
    else {
        window.location.href = "/Payment/Payment"
    }
}
function Checkout2() {
    if ($("#Dangnhap").html() == "Đăng nhập") {
        $("#closeCart").click();
        $("#Singin").click();
    }
    else {
        window.location.href = "/Home/viewCart"
    }
}
function RemoveCartSQL(ob, user) {
    $.ajax({
        url: "/Home/RemoveCart",
        type: 'Post',
        dataType: "json",
        data: { id: ob, Username: user },
        success: function (res) {
            $("#success").click(function () {
                $.toast({
                    heading: 'Success',
                    text: 'Bạn đã xóa khỏi giỏ hàng',
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
            common.loadData();
            $("#success").click()
        }
    });
}
function RemoveCartLocal(id) {
    var list = JSON.parse(localStorage.getItem('Cart')) || [];
    var index = list.findIndex(x => x.Id == id);
    if (index >= 0) {
        list.splice(index, 1);
        localStorage["Cart"] = JSON.stringify(list)
        common.loadData()
        $("#success").click(function () {
            $.toast({
                heading: 'Success',
                text: 'Bạn đã xóa khỏi giỏ hàng',
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
        common.loadData();
        $("#success").click()
    }

}
function UpdateCartSql(data, user) {
    $.ajax({
        url: "/Home/UpdateSLC",
        type: 'POST',
        dataType: "json",
        data: {
            model: JSON.stringify(data), Username: user
        }, success: function () {
            common.loadData();
        }
    })
}
function UpdateCartLocal(id, quantity) {
    var list = JSON.parse(localStorage.getItem('Cart')) || [];
    for (let x of list) {
        if (x.Id == id) {
            x.Quantity = quantity
            break;
        }
    }
    localStorage.setItem("Cart", JSON.stringify(list));
    common.loadData();

}
function LoadCartSQL(use) {
    $.ajax({
        url: "/Home/Cart",
        dataType: "json",
        data: { Username: use },
        success: function (res) {
            if (res.status) {
                var details = res.Data;
                var html = '';
                var datatable = $('#addCart').html();
                var x = 0;
                var s = 0;
                $.each(details, function (i, item) {
                    promotion.forEach(function (s) {
                        var arary = s.Apply.split(',')
                        if (arary.includes(item.ProName)) {
                            console.log(arary)
                            item.Cost = item.Cost * (100 - s.SoGiam) / 100
                        }
                    })
                    s = s + item.Quantity
                    x = x + item.Quantity * item.Cost;
                    html += Mustache.render(datatable, {
                        Id: item.ProID,
                        ProImage: item.ProImage,
                        ProName: item.ProName,
                        Cost: (item.Cost).toLocaleString('de-DE', {
                            maximumFractionDigits: currencyFractionDigits
                        }) + 'đ ',
                        Quantity: item.Quantity
                    });
                });
               
                $("#Soluong").html(s);
                $('#AddCart').html(html);
                $('#Tongtien').html(x.toLocaleString('de-DE', {
                    maximumFractionDigits: currencyFractionDigits
                }) + 'đ ')
            }
        },
    })
}
function LoadCartLocal() {
    var listcart = JSON.parse(localStorage.getItem('Cart')) || [];
    var datatable = $('#addCart').html();
    var html = '';
    var c = 0;
    var s = 0;
    for (x of listcart) {
        promotion.forEach(function (s) {
            var arary = s.Apply.split(',')
            if (arary.includes(item.ProName)) {
                console.log(arary)
                item.Cost = item.Cost * (100 - s.SoGiam) / 100
            }
        })
        c = c + x.Quantity * x.Cost;
        s = parseInt(s) + parseInt(x.Quantity);
        html += Mustache.render(datatable, {
            Id: x.Id,
            ProImage: x.Image,
            ProName: x.Name,
            Cost: (x.Cost).toLocaleString('de-DE', {
                maximumFractionDigits: currencyFractionDigits
            }) + 'đ ',
            Quantity: x.Quantity
        });
    }
    $("#Soluong").html(s)
    $('#AddCart').html(html);
    $('#Tongtien').html(c.toLocaleString('de-DE', {
        maximumFractionDigits: currencyFractionDigits
    }) + 'đ ')

}
function addCartLocal(id, name, image, cost) {
    var cartlist = {
        Id: id,
        Name: name,
        Image: image,
        Cost: cost,
        Quantity: 1
    };
    var list;
    if (localStorage.getItem('Cart') == null) {
        list = [cartlist];
    }
    else {
        list = JSON.parse(localStorage.getItem('Cart')) || [];
        let ok = true;
        for (let x of list) {
            if (x.Id == cartlist.Id) {
                x.Quantity = 1 + parseInt(x.Quantity)
                ok = false;
                break;
            }
        }
        if (ok) {
            list.push(cartlist);
        }
    }
    localStorage.setItem("Cart", JSON.stringify(list));
}