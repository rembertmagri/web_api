var itemsDataTable;
$(document).ready(function () {
    itemsDataTable = $('#itemDataTable').DataTable({
        serverSide: true,
        processing: true,
        searching: false,
        ordering: false,
        ajax: {
            url: '/api/TodoItem/GetDataTable',
            type: 'GET'
        },
        "columns": [
                { "data": "Id", "orderable": true },
                { "data": "Name", "orderable": false },
                { "data": "IsComplete", "orderable": true },
                {
                    "data": "Id", "render": function (data) {
                        return '<a href=javascript:ShowReadModal(' + data + '); class="btn btn-info">Details</a>&nbsp;' +
                                '<a href=javascript:ShowUpdateModal(' + data + '); class="btn btn-warning">Edit</a>&nbsp;' +
                                '<a href=javascript:ShowDeleteModal(' + data + '); class="btn btn-danger">Delete</a>';
                    }
                }
        ],
        "order": [[0, "asc"]]
    });

    $('#createNewjQuery').click(function (event) {
        var form, dialog;
        event.preventDefault();
        $.get("/Home/Create", function (data) {
            $('#renderModal').html(data);
            dialog = $("#renderModal").dialog({
                width: 400,
                modal: true,
                buttons: {
                    Cancel: function () {
                        dialog.dialog("close");
                    }
                }
            });
            form = dialog.find("form").on("submit", function (event) {
                event.preventDefault();
                $.ajax({
                    method: "POST",
                    url: "/api/TodoItem",
                    data: form.serialize(),
                    dataType: "application/json",
                    statusCode: {
                        201: function () {
                            dialog.dialog("close");
                            itemsDataTable.draw(false);
                        },
                        400: function () { alert("bad request"); },
                        500: function () { alert("internal server error"); }
                    }
                });
            });
        });
    });

});

function ShowReadModal(id) {
    $.get("/Home/Details/" + id, function (data) {
        $('#renderModal').html(data);
        dialog = $("#renderModal").dialog({
            width: 400,
            modal: true,
            buttons: {
                Cancel: function () {
                    dialog.dialog("close");
                }
            }
        });
    });
};

function ShowUpdateModal(id) {
    $.get("/Home/Edit/" + id, function (data) {
        $('#renderModal').html(data);
        dialog = $("#renderModal").dialog({
            width: 400,
            modal: true,
            buttons: {
                Cancel: function () {
                    dialog.dialog("close");
                }
            }
        });
        form = dialog.find("form").on("submit", function (event) {
            event.preventDefault();
            $.ajax({
                method: "PUT",
                url: "/api/TodoItem/" + id,
                data: form.serialize(),
                dataType: "application/json",
                statusCode: {
                    204: function () {
                        dialog.dialog("close");
                        itemsDataTable.draw(false);
                    },
                    400: function () { alert("bad request"); },
                    500: function () { alert("internal server error"); }
                }
            });
        });
    });
};

function ShowDeleteModal(id) {
    $.get("/Home/Delete/" + id, function (data) {
        $('#renderModal').html(data);
        dialog = $("#renderModal").dialog({
            width: 400,
            modal: true,
            buttons: {
                Cancel: function () {
                    dialog.dialog("close");
                }
            }
        });
        form = dialog.find("form").on("submit", function (event) {
            event.preventDefault();
            $.ajax({
                method: "DELETE",
                url: "/api/TodoItem/" + id,
                data: form.serialize(),
                dataType: "application/json",
                statusCode: {
                    204: function () {
                        dialog.dialog("close");
                        itemsDataTable.draw(false);
                    },
                    500: function () { alert("internal server error"); }
                }
            });
        });
    });
};