
$(document).ready(function () {
    $('#productsTable').DataTable({
        // Türkçe Dil Ayarı
        language: {
            "sDecimal": ",",
            "sEmptyTable": "Tabloda herhangi bir veri mevcut değil",
            "sInfo": "_TOTAL_ kayıttan _START_ - _END_ arasındaki kayıtlar gösteriliyor",
            "sInfoEmpty": "Kayıt yok",
            "sInfoFiltered": "(_MAX_ kayıt içerisinden bulunan)",
            "sInfoPostFix": "",
            "sInfoThousands": ".",
            "sLengthMenu": "Sayfada _MENU_ kayıt göster",
            "sLoadingRecords": "Yükleniyor...",
            "sProcessing": "İşleniyor...",
            "sSearch": "Ara:",
            "sZeroRecords": "Eşleşen kayıt bulunamadı",
            "oPaginate": {
                "sFirst": "İlk",
                "sLast": "Son",
                "sNext": "Sonraki",
                "sPrevious": "Önceki"
            },
            "oAria": {
                "sSortAscending": ": artan sütun sıralamasını aktifleştir",
                "sSortDescending": ": azalan sütun sıralamasını aktifleştir"
            },
            "select": {
                "rows": {
                    "_": "%d kayıt seçildi",
                    "0": "",
                    "1": "1 kayıt seçildi"
                }
            }
        }
    });
    // Türkçe Dil Ayarı

    

    // Ajax POST / Delete Start
    $(document).on('click', '.btn-delete',
        function (event) {
            event.preventDefault();
            const id = $(this).attr('productId');
            const tableRow = $(`[name="${id}"]`);
            const productName = tableRow.find('td:eq(2)').text();
            Swal.fire({
                title: 'Silmek istediğinize emin misiniz?',
                text: `${productName} adlı ürün silinecektir!`,
                icon: 'warning',
                showCancelButton: true,
                confirmButtonColor: '#3085d6',
                cancelButtonColor: '#d33',
                confirmButtonText: 'Evet, silmek istiyorum.',
                cancelButtonText: 'Hayır, silmek istemiyorum.'
            }).then((result) => {
                if (result.isConfirmed) {
                    $.ajax({
                        type: 'POST',
                        dataType: 'json',
                       /* Buradaki productId değeri Controller'daki Action'ın beklediği isim, Id değeri ise tableRowdan(name attribute'den) aldığım Id değeridir. */
                        data: { productId: id },
                        url: '/Admin/Product/Delete/', /*'@Url.Action("Delete","Product")'*/
                        success: function (data) {
                            const productResult = jQuery.parseJSON(data);
                            if (productResult.ResultStatus === 0) {
                                Swal.fire(
                                    'Silindi!',
                                    `${productResult.Message}`,
                                    'success'
                                );
                                tableRow.remove().draw();
                            } else {
                                Swal.fire({
                                    icon: 'error',
                                    title: 'Başarısız İşlem!',
                                    text: `${productResult.Message}`
                                });
                            }
                        },
                        error: function () {
                            alert("Bir hata oluştu!");
                        }
                    });
                }
            });
        }
    );
    // Ajax POST / Delete End

    // Ajax POST / HardDelete Start
    $(document).on('click', '.btn-hardDelete',
        function (event) {
            event.preventDefault();
            const id = $(this).attr('productId');
            const tableRow = $(`[name="${id}"]`);
            const productName = tableRow.find('td:eq(1)').text();
            Swal.fire({
                title: 'Kalıcı olarak silmek istediğinize emin misiniz?',
                text: `( "${productName}" adlı ürün kalıcı olarak silinecektir! )`,
                icon: 'warning',
                showCancelButton: true,
                confirmButtonColor: '#3085d6',
                cancelButtonColor: '#d33',
                confirmButtonText: 'Evet, kalıcı olarak silmek istiyorum.',
                cancelButtonText: 'Hayır, istemiyorum.'
            }).then((result) => {
                if (result.isConfirmed) {
                    $.ajax({
                        type: 'POST',
                        dataType: 'json',
                        data: { productId: id },
                        url: '/Admin/Product/HardDelete/',
                        success: function (data) {
                            const product = jQuery.parseJSON(data);
                            if (product.ResultStatus === 0) {
                                Swal.fire(
                                    'Kalıcı olarak silindi!',
                                    `${product.Message}`,
                                    'success'
                                );
                                tableRow.fadeOut(3000);
                            } else  {
                                Swal.fire({
                                    icon: 'error',
                                    title: 'Başarısız İşlem!',
                                    text: `${product.Message}`,
                                });
                            }
                        },
                        error: function () {
                            alert("Hatalı işlem !");
                        }
                    });
                }
            });
        }
    );
    // Ajax POST / HardDelete End

    /* Get Detail Ajax Operation */
    $(function () {
        const url = '/Admin/Product/GetDetail';
        const placeHolderDiv = $('#modalPlaceHolder');
        $(document).on('click', '.btn-detail',
            function (event) {
                event.preventDefault();
                const id = $(this).attr('productId');
                $.get(url, { productId: id }).done(function (data) {
                    placeHolderDiv.html(data);
                    placeHolderDiv.find('.modal').modal('show');
                }).fail(function () {
                    alert("Hatalı İşlem!");
                });
            });
    });
    /* Get Detail Ajax Operation */

    /* UndoDelete */
    $(document).on('click', '.btn-undo',
        function (event) {
            event.preventDefault();
            const id = $(this).attr('productId');
            const tableRow = $(`[name="${id}"]`);
            const productName = tableRow.find('td:eq(1)').text();
            Swal.fire({
                title: 'Arşivden geri getirmek istediğinize emin misiniz?',
                text: `${productName} adlı ürün arşivden geri getirilecektir!`,
                icon: 'question',
                showCancelButton: true,
                confirmButtonColor: '#3085d6',
                cancelButtonColor: '#d33',
                confirmButtonText: 'Evet, arşivden geri getirmek istiyorum.',
                cancelButtonText: 'Hayır,  istemiyorum.'
            }).then((result) => {
                if (result.isConfirmed) {
                    $.ajax({
                        type: 'POST',
                        dataType: 'json',
                        data: { productId: id },
                        url: '/Admin/Product/UndoDelete/',
                        success: function (data) {
                            const undoProductResult = jQuery.parseJSON(data);
                            if (undoProductResult.ResultStatus === 0) {
                                Swal.fire(
                                    'Arşivden Geri Getirildi!',
                                    `${undoProductResult.Message}`,
                                    'success'
                                );
                                tableRow.remove().draw();
                            } else {
                                Swal.fire({
                                    icon: 'error',
                                    title: 'Başarısız İşlem!',
                                    text: `${undoProductResult.Message}`
                                });
                            }
                        },
                        error: function () {
                            alert("Hatalı işlem!");
                        }
                    });
                }
            });
        }
    );
    /* UndoDelete */
    
});