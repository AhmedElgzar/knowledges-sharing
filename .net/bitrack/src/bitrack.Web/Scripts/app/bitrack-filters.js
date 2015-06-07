var bi_filters = function(){
    var filter_list = [];
    return {
        init: function(){
            var now = new Date();
            $('.input-daterange').datepicker({
                todayHighlight: true,
                orientation: "top right",
                autoclose: true,
                format: "dd/mm/yyyy",
                endDate: now.day+"/"+(now.month+1)+"/"+now.year
            });

            $('.add-filter').click(function(e){
                e.preventDefault();
                filter_list.push( { "id" : filter_list.length } );
                bi_filters.refresh_filter();
            });

            $(document).on('click','.remove-filter', function(e){
                e.preventDefault();
                var id = parseInt($(this).data('id'));
                filter_list.splice(id, 1);
                _.map(filter_list, function(item, index){
                   item.id = index;
                });
                bi_filters.refresh_filter();
            });
        },
        refresh_filter: function(){
            var template = _.template($('#filter_template').html());
            $('.filter-list').html(template({'filters' : filter_list}));
        }
    }
}();