
$(document).ready(function () {
    $('#categoriesTable').DataTable({
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
            const id = $(this).attr('categoryId');
            const tableRow = $(`[name="${id}"]`);
            const categoryName = tableRow.find('td:eq(1)').text();
            Swal.fire({
                title: 'Silmek istediğinize emin misiniz?',
                text: `${categoryName} adlı kategori silinecektir!`,
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
                        url: '/Admin/Category/Delete/', /*'@Url.Action("Delete","Category")'*/
                        success: function (data) {
                            const categoryDto = jQuery.parseJSON(data);
                            if (categoryDto.ResultStatusBase === 0) {
                                Swal.fire(
                                    'Silindi!',
                                    `${categoryDto.MessageBase}`,
                                    'success'
                                );
                                tableRow.remove().draw();
                            } else {
                                Swal.fire({
                                    icon: 'error',
                                    title: 'Başarısız İşlem!',
                                    text: `${categoryBase.Message}`
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
            const id = $(this).attr('categoryId');
            const tableRow = $(`[name="${id}"]`);
            const categoryName = tableRow.find('td:eq(1)').text();
            Swal.fire({
                title: 'Kalıcı olarak silmek istediğinize emin misiniz?',
                text: `( "${categoryName}" adlı kategori kalıcı olarak silinecektir! )`,
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
                        data: { categoryId: id },
                        url: '/Admin/Category/HardDelete/',
                        success: function (data) {
                            const hardDeleteResult = jQuery.parseJSON(data);
                            if (hardDeleteResult.ResultStatus === 0) {
                                Swal.fire(
                                    'Kalıcı olarak silindi!',
                                    `${hardDeleteResult.Message}`,
                                    'success'
                                );
                                tableRow.fadeOut(3000);
                            } else if (category.ResultStatus === 1) {
                                Swal.fire({
                                    icon: 'error',
                                    title: 'Başarısız İşlem!',
                                    text: `${hardDeleteResult.Message}`,
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

    /* UndoDelete */
    $(document).on('click', '.btn-undo',
        function (event) {
            event.preventDefault();
            const id = $(this).attr('categoryId');
            const tableRow = $(`[name="${id}"]`);
            const categoryName = tableRow.find('td:eq(1)').text();
            Swal.fire({
                title: 'Arşivden geri getirmek istediğinize emin misiniz?',
                text: `${categoryName} adlı kategori arşivden geri getirilecektir!`,
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
                        data: { categoryId: id },
                        url: '/Admin/Category/UndoDelete/',
                        success: function (data) {
                            const undoDeletedCategoryResult = jQuery.parseJSON(data);
                            if (undoDeletedCategoryResult.ResultStatusBase === 0) {
                                Swal.fire(
                                    'Arşivden Geri Getirildi!',
                                    `${undoDeletedCategoryResult.MessageBase}`,
                                    'success'
                                );
                                tableRow.remove().draw();
                            } else {
                                Swal.fire({
                                    icon: 'error',
                                    title: 'Başarısız İşlem!',
                                    text: `${undoDeletedCategoryResult.MessageBase}`
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