
$(document).ready(function () {
    $('#commentsTable').DataTable({
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
            const id = $(this).attr('commentId');
            const tableRow = $(`[name="${id}"]`);
            const commentName = tableRow.find('td:eq(1)').text();
            Swal.fire({
                title: 'Silmek istediğinize emin misiniz?',
                text: `${commentName} adlı yorum silinecektir!`,
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
                        data: { commentId: id },
                        url: '/Admin/Comment/Delete/', /*'@Url.Action("Delete","Comment")'*/
                        success: function (data) {
                            const commentResult = jQuery.parseJSON(data);
                            if (commentResult.Data) {
                                Swal.fire(
                                    'Silindi!',
                                    `${commentResult.Data.Comment.Id} no'lu yorum başarıyla silinmiştir.`,
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

    /* Ajax POST / HardDelete Start*/
    $(document).on('click', '.btn-hardDelete',
        function (event) {
            event.preventDefault();
            const id = $(this).attr('commentId');
            const tableRow = $(`[name="${id}"]`);
            const commetnName = tableRow.find('td:eq(0)').text();
            Swal.fire({
                title: 'Kalıcı olarak silmek istediğinize emin misiniz?',
                text: `( "${commetnName}" Id'li' yorum kalıcı olarak silinecektir! )`,
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
                        data: { commentId: id },
                        url: '/Admin/Comment/HardDelete/' ,
                        success: function (data) {
                            const Comment = jQuery.parseJSON(data);
                            if (Comment.ResultStatus === 0) {
                                Swal.fire(
                                    'Kalıcı olarak silindi!',
                                    `${Comment.Message}`,
                                    'success'
                                );
                                tableRow.fadeOut(3000);
                            } else if (Comment.ResultStatus === 1) {
                                Swal.fire({
                                    icon: 'error',
                                    title: 'Başarısız İşlem!',
                                    text: `${Comment.Message}`,
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
    /* Ajax POST / HardDelete End */

    /* UndoDelete */
    $(document).on('click', '.btn-undo',
        function (event) {
            event.preventDefault();
            const id = $(this).attr('commentId');
            const tableRow = $(`[name="${id}"]`);
            const commentName = tableRow.find('td:eq(1)').text();
            Swal.fire({
                title: 'Arşivden geri getirmek istediğinize emin misiniz?',
                text: `${commentName} Id'li yorum arşivden geri getirilecektir!`,
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
                        data: { commentId: id },
                        url: '/Admin/Comment/UndoDelete/',
                        success: function (data) {
                            const commentResult = jQuery.parseJSON(data);
                            if (commentResult.Data) {
                                Swal.fire(
                                    'Arşivden Geri Getirildi!',
                                    `${commentResult.Data.Comment.Id} no'lu yorum arşivden geri getirilmiştir.`,
                                    'success'
                                );
                                tableRow.remove().draw();
                            } else {
                                Swal.fire({
                                    icon: 'error',
                                    title: 'Başarısız İşlem!',
                                    text: `Beklenmedik bir hata oluştu.`
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


    /* Get Detail Ajax Operation */
    $(function () {
        const url = '/Admin/Comment/GetDetail';
        const placeHolderDiv = $('#modalPlaceHolder');
        $(document).on('click', '.btn-detail',
            function (event) {
                event.preventDefault();
                const id = $(this).attr('commentId');
                $.get(url, { commentId: id }).done(function (data) {
                    placeHolderDiv.html(data);
                    placeHolderDiv.find('.modal').modal('show');
                }).fail(function () {
                    alert("Hatalı İşlem!");
                });
            });
    });
    /* Get Detail Ajax Operation */

    // Ajax POST / Approve Start
    $(document).on('click', '.btn-approve',
        function (event) {
            event.preventDefault();
            const id = $(this).attr('commentId');
            const tableRow = $(`[name="${id}"]`);
            const commentNo = tableRow.find('td:eq(0)').text();
            Swal.fire({
                title: 'Onaylamak istediğinize emin misiniz?',
                text: `(${commentNo}) No'lu yorum onaylanacaktır!`,
                icon: 'info',
                showCancelButton: true,
                confirmButtonColor: '#3085d6',
                cancelButtonColor: '#d33',
                confirmButtonText: 'Evet, onaylamak istiyorum.',
                cancelButtonText: 'Hayır, onaylamak istemiyorum.'
            }).then((result) => {
                if (result.isConfirmed) {
                    $.ajax({
                        type: 'POST',
                        dataType: 'json',
                        data: { commentId: id },
                        url: '/Admin/Comment/Approve/', /*'@Url.Action("Approve","Comment")'*/
                        success: function (data) {
                            const commentResult = jQuery.parseJSON(data);
                            if (commentResult.Data) {
                                Swal.fire(
                                    'Onaylandı!',
                                    `${commentResult.Data.Comment.Id} no'lu yorum başarıyla onaylanmıştır.`,
                                    'success'
                                ).then(function () {
                                    location.reload();
                                    window.location.reload();
                                });
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
    // Ajax POST / Approve End

    // Ajax POST / NOT Approve Start
    $(document).on('click', '.btn-notApprove',
        function (event) {
            event.preventDefault();
            const id = $(this).attr('commentId');
            const tableRow = $(`[name="${id}"]`);
            const commentNo = tableRow.find('td:eq(0)').text();
            Swal.fire({
                title: 'Onayı kaldırmak istediğinize emin misiniz?',
                text: `(${commentNo}) No'lu yorumun onayı kaldırılacaktır!`,
                icon: 'info',
                showCancelButton: true,
                confirmButtonColor: '#3085d6',
                cancelButtonColor: '#d33',
                confirmButtonText: 'Evet, onayı kaldırmak istiyorum.',
                cancelButtonText: 'Hayır, onayı kaldırmak istemiyorum.'
            }).then((result) => {
                if (result.isConfirmed) {
                    $.ajax({
                        type: 'POST',
                        dataType: 'json',
                        data: { commentId: id },
                        url: '/Admin/Comment/Approve/', /*'@Url.Action("Approve","Comment")'*/
                        success: function (data) {
                            const commentResult = jQuery.parseJSON(data);
                            if (commentResult.Data) {
                                Swal.fire(
                                    'Onay Kaldırıldı!',
                                    `${commentResult.Data.Comment.Id} no'lu yorumun onayı kaldırılmıştır.`,
                                    'success'
                                ).then(function () {
                                    location.reload();
                                });
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
                        },
                    });
                }
            });
        }
    );
    // Ajax POST / NOT Approve End

   
});

