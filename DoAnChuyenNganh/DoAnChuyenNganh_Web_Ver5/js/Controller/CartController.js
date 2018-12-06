var cart = {
    init: function () {
        cart.regEvents();
    },
    regEvents: function () {
        $('#btnContinue').off('click').on('click', function () {
            window.location.href = "/";
        })

        $('#btnPayment').off('click').on('click', function () {
            window.location.href = "/thanh-toan"; //ánh xạ tới đâu khi click
        })

        $('#btnUpdate').off('click').on('click', function () {
            var listProduct = $('.txtQuantity');
            var cartList = [];//Tạo mảng danh sách các item trong cart
            $.each(listProduct, function (i, item) {
                cartList.push({     //push từng đối tượng của item vào mảng
                    Quantity: $(item).val(),
                    product: {
                        PrID: $(item).data('id') //Gán thuộc tính của đối tượng mã sản phẩm trong tb Product
                    }
                });
            });

            $.ajax({
                url: '/Cart/Update',
                data: { cartModel: JSON.stringify(cartList) },
                dataType: 'json',
                type: 'POST',
                success: function (res) { //res = respond
                    if (res.status === true) {
                        window.location.href = "/gio-hang";
                    }
                }
            })
        });

        $('#btnDeleteAll').off('click').on('click', function () {
            $.ajax({
                url: '/Cart/DeleteAll',
                dataType: 'json',
                type: 'POST',
                success: function (res) { //res = respond
                    if (res.status === true) {
                        window.location.href = "/gio-hang";
                    }
                }
            })
        });

        $('#btn-delete').off('click').on('click', function (e) {
            e.prevenDefault();
            $.ajax({
                data: { id: $(this).data('id') },//lấy data 
                url: '/Cart/Delete',
                dataType: 'json',
                type: 'POST',
                success: function (res) { //res = respond
                    if (res.status === true) {
                        window.location.href = "/gio-hang";
                    }
                }
            })
        });

        $('.btn-delete').off('click').on('click', function (e) {
            e.preventDefault();
            $.ajax({
                data: { id: $(this).data('id') },
                url: '/Cart/Delete',
                dataType: 'json',
                type: 'POST',
                success: function (res) {
                    if (res.status == true) {
                        window.location.href = "/gio-hang";
                    }
                }
            })
        });
    }
}
cart.init();