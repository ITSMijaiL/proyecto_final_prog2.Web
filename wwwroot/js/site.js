// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

/* 
disabled?: boolean | undefined;
        addClasses?: boolean | undefined;
        appendTo?: any;
        axis?: string | undefined;
        cancel?: string | undefined;
        classes?: DraggableClasses | undefined;
        connectToSortable?: Element | Element[] | JQuery | string | undefined;
        containment?: any;
        cursor?: string | undefined;
        cursorAt?: any;
        delay?: number | undefined;
        distance?: number | undefined;
        grid?: number[] | undefined;
        handle?: any;
        helper?: any;
        iframeFix?: any;
        opacity?: number | undefined;
        refreshPositions?: boolean | undefined;
        revert?: any;
        revertDuration?: number | undefined;
        scope?: string | undefined;
        scroll?: boolean | undefined;
        scrollSensitivity?: number | undefined;
        scrollSpeed?: number | undefined;
        snap?: any;
        snapMode?: string | undefined;
        snapTolerance?: number | undefined;
        stack?: string | undefined;
        zIndex?: number | undefined;
*/
$(function () {
    /*$(".task").draggable({
        stop: function (event, ui) {
            // on older version of jQuery use "draggable"
            // $(this).data("draggable")
            // on 2.x versions of jQuery use "ui-draggable"
            // $(this).data("ui-draggable")
            $(this).data("uiDraggable").originalPosition = {
                top: 0,
                left: 0
            };
            // return boolean
            return event;
            // that evaluate like this:
            // return event !== false ? false : true;
        }
    });
    $(".column").droppable(
        {
            drop: function (event, ui) {
                console.log(ui);
                console.log(event);
                ui.draggable = false;
            }
        }
    );*/

    /*$(".task").sortable({
        connectWith: ".column"
    }).disableSelection();*/
    $("")
    $(".column").sortable({
        connectWith: ".column",
        cursor: "move",
        helper: "clone",
        items: "> div",
        stop: function (event, ui) {
            var $item = ui.item;
            /*var eventLabel = $item.text();
            var newDay = $item.parent().attr("id");*/

            //console.log($item.parent().find("h2").text());
            console.log($item.find("> p").text());
            var id_task;
            $.get({
                url: "https://localhost:7052/api/Tasks/ID/" + $item.find("> p").text(),
                success: (response) => {
                    id_task = response;
                },
                async: false
            });
            var id_col;
            $.get({
                url: "https://localhost:7052/api/Columns/ID/" + $item.parent().find("> h2").text(),
                success: (response) => {
                    id_col = response;
                },
                async: false
            });
                $.ajax(`https://localhost:7052/api/Tasks/${id_task}/${id_col}`, {
                    type: "PUT"
                });

            }
        }).disableSelection();
});

