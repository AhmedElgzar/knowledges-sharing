$(document).ready(function(){
    $('body').append('<div id="player"></div>');
    var player = $("#player");
    player.jPlayer({
        swfPath: "/static/js/jplayer/Jplayer.swf",
        ready: function(){
        }
    });

   $('.play').click(function(e){
       e.preventDefault();
       player.jPlayer('stop');
       if($(this).text()=="Play"){
           $('.play').each(function(){
               $(this).text("Play");
           });
           $(this).text("Stop");
           player.jPlayer('setMedia',{
                mp3: $(this).attr('href')
            });
           player.jPlayer('play');
       }
       else{
           $(this).text("Play");
       }
   });
});