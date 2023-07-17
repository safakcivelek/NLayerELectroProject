$(document).ready(function () {
    $('#userTable').DataTable({
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
    // Ajax POST / User_Delete Start
    $(document).on('click', '.btn-delete',
        function (event) {
            event.preventDefault();
            const id = $(this).attr('userId');
            const tableRow = $(`[name="${id}"]`);
            const userName = tableRow.find('td:eq(1)').text();
            Swal.fire({
                title: 'Silmek istediğinize emin misiniz?',
                text: `${userName} adlı kullanıcı silinecektir!`,
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
                        data: { userId: id },
                        url: '/Admin/User/Delete/', /*'@Url.Action("Delete","User")'*/
                        success: function (data) {
                            const userDto = jQuery.parseJSON(data);
                            if (userDto.ResultStatusBase === 0) {
                                Swal.fire(
                                    'Silindi!',
                                    `${userDto.MessageBase}`,
                                    'success'
                                );                               
                                tableRow.remove().draw();                          
                            }else {
                                Swal.fire({
                                    icon: 'error',
                                    title: 'Başarısız İşlem!',
                                    text: `${userDto.MessageBase}`
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
    // Ajax POST / User_Delete End

    // Ajax POST / User_HardDelete Start
    $(document).on('click', '.btn-hardDelete',
        function (event) {
            event.preventDefault();
            const id = $(this).attr('categoryId');
            const tableRow = $(`[name="${id}"]`);
            const categoryName = tableRow.find('td:eq(1)').text();
            Swal.fire({
                title: 'Tamamen silmek istediğinize emin misiniz?',
                text: `( "${categoryName}" adlı kategori veritabanından silinecektir! )`,
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
                        data: { categoryId: id },
                        url: '/Admin/Category/HardDelete/' /*'@Url.Action("Delete","Category")'*/,
                        success: function (data) {
                            const category = jQuery.parseJSON(data);
                            if (category.ResultStatus === 0) {
                                Swal.fire(
                                    'Silindi!',
                                    `${category.Message}`,
                                    'success'
                                );
                                tableRow.fadeOut(3000);
                            } else if (category.ResultStatus === 1) {
                                Swal.fire({
                                    icon: 'error',
                                    title: 'Başarısız İşlem!',
                                    text: `${category.Message}`,
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
    // Ajax POST / User_HardDelete End

    /* Get Detail Ajax Operation */
    $(function () {
        const url = '/Admin/User/GetDetail';
        const placeHolderDiv = $('#modalPlaceHolder');
        $(document).on('click', '.btn-detail',
            function (event) {
                event.preventDefault();
                const id = $(this).attr('userId');
                $.get(url, { userId: id }).done(function (data) {
                    placeHolderDiv.html(data);
                    placeHolderDiv.find('.modal').modal('show');
                }).fail(function () {
                    alert("Hatalı İşlem!");
                });
            });
    });
    /* Get Detail Ajax Operation */
});

   
