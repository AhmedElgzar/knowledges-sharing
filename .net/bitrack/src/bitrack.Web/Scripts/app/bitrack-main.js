$(document).ready(function(){
    $('.sidebar-toggle').click(function(e){
        e.preventDefault();
        //todo; only for desktop
        if(window.innerWidth >= 768){
            $('body').toggleClass('sidebar-collapsed');
        }
        else{
            $('body').toggleClass('sidebar-open');
        }
    });

    bi_filters.init();
    bi_grids.init();
    bi_charts.init();
});