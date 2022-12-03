////var common = {
////    init: function () {
////        common.Search();
////    },
////    registerEvent: function () {
////    },
////    loadData: function () {
////        $.ajax({
////            url: "/Home/Cart",
////            dataType: "json",
////            success: function (res) {
////                if (res.status) {
////                    var details = res.Data;
////                    var html = '';
////                    var datatable = $('#addCart').html();
////                    var x = 0;
////                    $.each(details, function (i, item) {
////                        x = x + item.Quantity * item.Cost;
////                        html += Mustache.render(datatable, {
////                            Id: item.ProID,
////                            ProImage: item.ProImage,
////                            ProName: item.ProName,
////                            Cost: (item.Cost).toLocaleString('de-DE', {
////                                maximumFractionDigits: currencyFractionDigits
////                            }) + 'đ ',
////                            Quantity: item.Quantity
////                        });
////                    });
////                    $('#AddCart').html(html);
////                    $('#Tongtien').html(x.toLocaleString('de-DE', {
////                        maximumFractionDigits: currencyFractionDigits
////                    }) + 'đ ')
////                }
////            },
////        })
////    },
////    updateCart: function (idd) {
////        var data = {
////            ProID: idd,
////            Quantity: document.getElementById(idd).value
////        };
////        $.ajax({
////            url: "/Home/UpdateSLC",
////            type: 'POST',
////            dataType: "json",
////            data: {
////                model: JSON.stringify(data)
////            }, success: function () {
////                common.loadData();
////            }
////        })
////    },
////    removeCart: function (s) {
////        var ob = s;
////        $.ajax({
////            url: "/Home/RemoveCart",
////            type: 'Post',
////            dataType: "json",
////            data: { id: ob },
////            success: function () {
////                alert("Bạn đã xóa khỏi giỏ hàng")
////                common.loadData();
////            }
////        });
////    },
////    Search: function () {

////        $("#txtKeySP").autocomplete({
////            minLength: 0,
////            source: function (request, response) {
////                $.ajax({
////                    url: "/Admin/Products/ListName",
////                    dataType: "json",
////                    data: {
////                        q: request.term
////                    },
////                    success: function (res) {
////                        response(res.data);
////                    },
////                })
////            },
////            focus: function (event, ui) {
////                return false;
////            },
////            select: function (event, ui) {
////                $("#txtKeySP").val("");
////                $.ajax({
////                    url: "/Home/Search",
////                    dataType: "json",
////                    data: {
////                        id: ui.item.ProID
////                    },
////                    success: function (res) {
////                        if (res.status) {
////                            window.location.href = "/Home/SanPham";
////                        }
////                    },
////                })


////                return false;
////            }
////        })
////            .autocomplete("instance")._renderItem = function (ul, item) {
////                return $("<li id='SPkey' style='background-color: white;list-style: none;margin-left:-50px';margin-top:20px>")
////                    .append("<div class='row' style = 'max-width:300px' > <div class='col-4'> <img width='100%' src = " + item.ProImage + "> </div> <div class='col-8 mt-2' style:'font-size: 11px'> <p> " + item.ProName + "</p>  </div> </div>")
////                    .appendTo(ul);
////            }
////    },

////}
////common.init();