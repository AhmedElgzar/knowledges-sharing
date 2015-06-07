var bi_grids = function(){
    var init_columns = ['0','1','2','3'];
    return {
        init: function(){
            $.extend( $.fn.dataTable.defaults, {
                "searching": false
            });
            var grid = $('#data_grid').DataTable({
                "columns": [
                    {
                        "data": "Name",
                        "data": "TotalVisits",
                        "data": "NewVisits",
                        "data": "ReturningVisits",
                        "data": "Browser",
                        "data": "OS",
                        "data": "Language",
                        "data": "Location"
                    }
                ],
                "processing": true,
                "serverSide": true,
                "ajax": {
                    "url": "/internal/pageview",
                    "type": "POST",
                    "data": function(d){
                        d.start_date = $('#start_date').val();
                        d.end_date = $('#end_date').val()
                    }
                }
            });

            if(localStorage.getItem('pageview_columns')){
                init_columns = localStorage.getItem('pageview_columns').split(',');
            }
            grid.columns().every(function () {
                this.visible(false);
            });
            for(var i=0; i<init_columns.length; i++){
                var column = grid.column(init_columns[i]);
                column.visible(true);
                $('.colums-toggle .btn[data-column="'+i+'"]').addClass('active');
            }
            $('.toggle-column').on('click',function (e) {
                e.preventDefault();
                var column = grid.column($(this).data('column'));
                column.visible(!column.visible());
                if(column.visible()){
                    init_columns.push($(this).data('column'));
                }
                else{
                    init_columns.splice(init_columns.indexOf($(this).data('column')));
                }
                localStorage.setItem('pageview_columns', init_columns);
            });

            $('#search').click(function(e){
                e.preventDefault();
                grid.draw();
            });
        }
    };
}();