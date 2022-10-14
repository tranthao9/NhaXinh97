var product = {
    init: function () {
        product.registerEvents();
    },
    registerEvents: function() {
        $("#btnSelectImagePro").off('click').on('click', function (e) {
            e.preventDefault();
            var finder = new CKFinder();
            finder.selectActionFunction = function (url) {
                $('.ProNo').remove();
                $('#ImageList').append('<div class="mt-3 col-sm-4 d-flex"> <img width = "90%" height = "90%" src = "' + url + '"/><a class="ml-1 removeImg" href="#"> <i class="fa fa-times text-danger"> </i> </a> </div >')
                $('.removeImg').off('click').on('click', function (e) {
                    e.preventDefault();
                    $(this).parent().remove();
                })
            };
            finder.popup();
        });
        $('#saveImgPro').off('click').on('click', function () {
            var images = [];
            $.each($('#ImageList img'), function (i, item) {
                images.push($(item).prop('src'));
            })
            $("#SrcImgPro").val(images);
        });

    }
}
product.init();

