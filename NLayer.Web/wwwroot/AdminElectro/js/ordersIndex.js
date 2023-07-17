$(document).ready(function () {
    $('#ordersTable').DataTable({
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

    // Onay İptal
    $(document).on('click', '.btn-notApprove', function (event) {
        event.preventDefault();
        const id = $(this).attr('orderId');
        Swal.fire({
            title: '"Sipariş Onayını" iptal etmek istediğinize emin misiniz?',
            text: `( "${id} Id'li siparişin onayı iptal edilecektir!" )`,
            icon: 'info',
            showCancelButton: true,
            confirmButtonColor: '#3085d6',
            cancelButtonColor: '#d33',
            confirmButtonText: 'Evet, Onayı İptal Etmek İstiyorum.',
            cancelButtonText: 'Hayır, Onayı İptal Etmek İstemiyorum.'
        }).then((result) => {
            if (result.isConfirmed) {
                $.ajax({
                    type: 'POST',
                    dataType: 'json',
                    data: { orderId: id },
                    url: '/Admin/Order/Approve/',
                    success: function (data) {
                        const orderResult = jQuery.parseJSON(data);
                        if (orderResult.Data != null) {
                            Swal.fire(
                                'Sipariş Onayı İptal Edildi.',
                                `( "${orderResult.Data.Order.Id} Id'li siparişin onayı iptal edilmiştir." )`,
                                'success'
                            ).then(function () {
                                location.reload();
                            });
                        }
                        else {
                            Swal.fire({
                                icon: 'error',
                                title: 'Başarısız İşlem!',
                                text: 'Beklenmedik bir hata ile karşılaşıldı!'
                            });
                        }
                    },
                    error: function () {
                        alert("Hatalı İşlem!");
                    }
                });
            }
        });
    });
    // Onay İptal

    // Onay
    $(document).on('click', '.btn-approve', function (event) {
        event.preventDefault();
        const id = $(this).attr('orderId');
        Swal.fire({
            title: '"Siparişi Onaylamak" istediğinize emin misiniz?',
            text: `( "${id} Id'li sipariş onaylanacaktır!" )`,
            icon: 'info',
            showCancelButton: true,
            confirmButtonColor: '#3085d6',
            cancelButtonColor: '#d33',
            confirmButtonText: 'Evet, Onaylamak İstiyorum.',
            cancelButtonText: 'Hayır, Onaylamak İstemiyorum.'
        }).then((result) => {
            if (result.isConfirmed) {
                $.ajax({
                    type: 'POST',
                    dataType: 'json',
                    data: { orderId: id },
                    url: '/Admin/Order/Approve/',
                    success: function (data) {
                        const orderResult = jQuery.parseJSON(data);
                        if (orderResult.Data != null) {
                            Swal.fire(
                                'Sipariş Onaylandı.',
                                `( "${orderResult.Data.Order.Id} Id'li sipariş onaylandı." )`,
                                'success'
                            ).then(function () {
                                location.reload();
                            });
                        }
                        else {
                            Swal.fire({
                                icon: 'error',
                                title: 'Başarısız İşlem!',
                                text: 'Beklenmedik bir hata ile karşılaşıldı!'
                            });
                        }
                    },
                    error: function () {
                        alert("Hatalı İşlem!");
                    }
                });
            }
        });
    });
    // Onay

    /* Get Detail Ajax Operation */
    $(function () {
        const url = '/Admin/Order/GetDetail/';
        const placeHolderDiv = $('#modalPlaceHolder');
        $(document).on('click', '.btn-detail',
            function (event) {
                event.preventDefault();
                const id = $(this).attr('orderId');
                $.get(url, { orderId: id }).done(function (data) {
                    placeHolderDiv.html(data);
                    placeHolderDiv.find('.modal').modal('show');
                }).fail(function () {
                    alert("Hatalı İşlem!");
                });
            });
    });
    /* Get Detail Ajax Operation */

    // Ajax POST / Delete Start
    $(document).on('click', '.btn-delete',
        function (event) {
            event.preventDefault();
            const id = $(this).attr('orderId');
            const tableRow = $(`[name="${id}"]`);
            const orderName = tableRow.find('td:eq(0)').text();
            Swal.fire({
                title: 'Silmek istediğinize emin misiniz?',
                text: `${orderName} Id'li' sipariş silinecektir!`,
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
                        data: { orderId: id },
                        url: '/Admin/Order/Delete/',
                        success: function (data) {
                            const orderResult = jQuery.parseJSON(data);
                            if (orderResult.Data != null) {
                                Swal.fire(
                                    'Silindi!',
                                    `${orderResult.Data.Order.Id} no'lu sipariş başarıyla silinmiştir.`,
                                    'success'
                                );
                                tableRow.remove().draw();
                            } else {
                                Swal.fire({
                                    icon: 'error',
                                    title: 'Başarısız İşlem!',
                                    text: `Beklenmedik bir hata ile karşılaşıldı!`
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
    // Ajax POST / Delete End

    // Ajax POST / HardDelete Start
    $(document).on('click', '.btn-hardDelete',
        function (event) {
            event.preventDefault();
            const id = $(this).attr('orderId');
            const tableRow = $(`[name="${id}"]`);
            const orderName = tableRow.find('td:eq(0)').text();
            Swal.fire({
                title: 'Tamamen silmek istediğinize emin misiniz?',
                text: `( "${orderName}" Id'li' sipariş veritabanından silinecektir! )`,
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
                        data: { orderId: id },
                        url: '/Admin/Order/HardDelete/',
                        success: function (data) {
                            const orderResult = jQuery.parseJSON(data);
                            if (orderResult != null) {
                                Swal.fire(
                                    'Silindi!',
                                    `${orderResult.Message}`,
                                    'success'
                                );
                                tableRow.fadeOut(3000);
                            } else {
                                Swal.fire({
                                    icon: 'error',
                                    title: 'Başarısız İşlem!',
                                    text: `${orderResult.Message}`,
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
});