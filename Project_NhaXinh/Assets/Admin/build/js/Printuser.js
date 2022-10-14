var str = " <div id="doc2" class="yui - t7">
    < div id = "inner" >
            <div id="hd ">
                <div class="yui-gc d-flex yui-gf">
                    <img class="img-circle mb-3 ml-5" src="~/Assets/Admin/images/img.jpg" width="18%" alt="">
                    <div class="yui-u  ml-5 mt-5 pl-4">
                        <h2 class="h3">`+@Html.DisplayFor(model => model.Name)+`</h2><br />
                        <h2 class="h6">`+@Html.DisplayFor(model => model.Position)+`</h2> <br />
                        <h2 class="h6">Mã nhân viên : `+@Html.DisplayFor(model => model.UserID)+`</h2>
                    </div>

                    <div class="yui-u mt-3">
                        <div class="contact-info">
                            
                            <h3 class=" mt-2"><a href=""><i class="fa fa-envelope-o">  &ensp;  `+@Html.DisplayFor(model => model.UserEmail)+`</i>  </a></h3>
                            <h3 class="mt-2"><i class="fa fa-phone"></i> &ensp; `+@Html.DisplayFor(model => model.UserPhone)+`</h3>
                            <h4 class="mt-2"><i class="fa fa-birthday-cake"> </i> &ensp; `+@Html.FormatValue(Model.DateofBirth, "{0:yyyy-MM-dd}")+`</h4>
                        </div>
                    </div>
                </div>
            </div>

            <div id="bd">
                <div id="yui-main">
                    <div class="yui-b">
                        <div class="yui-gf d-flex ">
                            <div class="yui-u first text-right">
                                <div class="h5">Giới tính : </div>
                            </div>
                            <div class="yui-u">
                                <p class="enlarge">
                                    `+@Html.DisplayFor(model => model.Gender)+`
                                </p>
                            </div>
                        </div>
                        <div class="yui-gf d-flex ">
                            <div class="yui-u first text-right">
                                <div class="h5">  Địa chỉ : </div>
                            </div>
                            <div class="yui-u">
                                <p class="enlarge">
                                    `+@Html.DisplayFor(model => model.UserAddress)+`
                                </p>
                            </div>
                        </div>

                        <div class="yui-gf  d-flex ">
                            <div class="yui-u first text-right">
                                <div class="h5">   Thẻ căn cước công dân : </div>
                            </div>
                            <div class="yui-u">
                                <div class="yui-u">
                                    <p class="enlarge">
                                        `+@Html.DisplayFor(model => model.Identification)+`
                                    </p>
                                </div>
                            </div>
                        </div>
                        <div class="yui-gf  d-flex ">
                            <div class="yui-u first text-right">
                                <div class="h5">Ngày cấp : </div>
                            </div>
                            <div class="yui-u">
                                <div class="yui-u">
                                    <p class="enlarge">
                                        `+@Html.FormatValue(Model.DateofIssueinIDcard, "{0:yyyy-MM-dd}")+`
                                    </p>
                                </div>
                            </div>
                        </div>

                        <div class="yui-gf  d-flex ">
                            <div class="yui-u first text-right">
                                <div class="h5">Nơi cấp : </div>
                            </div>
                            <div class="yui-u">
                                <div class="yui-u">
                                    <p class="enlarge">
                                        `+@Html.DisplayFor(model => model.PlaceofIssueofIdentityCard)+`
                                    </p>
                                </div>
                            </div>
                        </div>
                        <div class="yui-gf  d-flex ">
                            <div class="yui-u first text-right">
                                <div class="h5"> Certificate : </div>
                            </div>
                            <div class="yui-u">
                                <div class="yui-u">
                                    <p class="enlarge">
                                        `+@Html.DisplayFor(model => model.Degree)+`
                                    </p>
                                </div>
                            </div>
                        </div>
                        <div class="yui-gf  d-flex ">
                            <div class="yui-u first text-right">
                                <div class="h5">Tình trạng hôn nhân : </div>
                            </div>
                            <div class="yui-u">
                                <div class="yui-u">
                                    <p class="enlarge">
                                        `+@Html.DisplayFor(model => model.MaritalSatus)+`
                                    </p>
                                </div>
                            </div>
                        </div>
                        <div class="yui-gf  d-flex ">
                            <div class="yui-u first text-right">
                                <div class="h5">UserName : </div>
                            </div>
                            <div class="yui-u">
                                <div class="yui-u">
                                    <p class="enlarge">
                                        `+@Html.DisplayFor(model => model.UserName)+`
                                    </p>
                                </div>
                            </div>
                        </div>
                        <div class="yui-gf  d-flex ">
                            <div class="yui-u first text-right">
                                <div class="h5">Trạng thái : </div>
                            </div>
                            <div class="yui-u">
                                <div class="yui-u">
                                    <p class="enlarge">
                                        `+@Html.DisplayFor(model => model.Status)+`
                                    </p>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>

            <div id="ft">
                <p>`+@Html.DisplayFor(model => model.Name)+` &mdash; <a>`+@Html.DisplayFor(model => model.UserEmail)+`</a> &mdash; `+@Html.DisplayFor(model => model.UserPhone)+`</p>
            </div>
        </div >
    </div > ";
function printPDF(data) {
    let popupWin = window.open('', '_blank', 'top=0,left=0,height=100%,width=auto');
    popupWin.document.write(`
      <html>
          <head>
          <title>Hóa đơn</title>
          <style>
              * {
                  margin: 0;
                  padding: 0;
              }
              table {
                  width: 100%;
              }
              .donvi {
                  font-size: 14px;
                  font-weight: bold;
              }
              body {
                  width: 1000px;
                  margin: 0 auto;
              }
          </style>
          </head>
      <body onload="window.print();window.close()">${data}</body>
      </html>`
    );
    popupWin.document.close();
}

function printP() {
    printPDF(str);
}