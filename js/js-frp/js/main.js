var human = {
    "image": "images/lola.png"
}

var womanHeightList = [155,157,160,163,165,168,170,171,173,175,178,180,183];
var maxWomanHeight = 183;

var humanImg = $('.human');
var productImg = $('.product');

var humanComparison = function(){
    return {
        init: function(){
            this.draggable(productImg);
            this.draggable(humanImg);
        },
        draggable: function(element){
            var browserDrag = element.asEventStream('dragstart');//.doAction(".preventDefault");
            browserDrag.onValue(function(e){
                e.preventDefault();
            });
            var dragStartStream = element.asEventStream('mousedown');
            var dragEndStream = $(window).asEventStream('mouseup');
            var dragStream = dragStartStream.flatMap(function(e){
                $('.human,.product').css('z-index','1');
                element.css('z-index','99');
                return $(window).asEventStream('mousemove').map(function(event){
                    event.startX = e.offsetX;
                    event.startY = e.offsetY;
                    return event;
                }).takeUntil(dragEndStream);
            });
            dragStream.onValue(function(e){
                element.css("left", e.pageX - e.startX);
                element.css("top", e.pageY - e.startY);
            });
        },
        loadProduct: function(){
            return Bacon.fromPromise($.get('js/product.json'));
        },
        calculateHumanHeight: function(product){
            humanImg.attr('src',human.image);
            productImg.attr('src',product.image);
            var containerHeight = $('.container').height();
            var maxHeight = product.dimensions.height>maxWomanHeight?product.dimensions.height:maxWomanHeight;
            var pxPerSm = containerHeight / maxHeight;
            var productHeight = product.dimensions.height * pxPerSm;
            productImg.height(productHeight);

            var increaseButtonStream = $('.btn-size.add').asEventStream('click');
            var decreaseButtonStream = $('.btn-size.delete').asEventStream('click');
            var counterStream = increaseButtonStream.map(1).merge(decreaseButtonStream.map(-1)).scan(0, function (acc, x){
                var sum = acc + x;
                if (sum<0) sum = womanHeightList.length-1;
                if (sum>womanHeightList.length-1) sum = 0;
                return sum;
            });
            var counterTextStream =  counterStream.map(function(value){
                return womanHeightList[value];
            });
            var imageHeightStream =  counterStream.map(function(value){
                var humanHeight = womanHeightList[value] * pxPerSm;
                return humanHeight;
            });

            counterTextStream.assign($('.current-height'), 'text');
            imageHeightStream.assign($('.human'), 'height');
            /*imageHeightStream.onValue(function(value){
             humanImg.height(value);
             });*/
        }
    }
}();


$(document).ready(function(){
    humanComparison.init();
    var productStream = humanComparison.loadProduct().onValue(function(data){
        humanComparison.calculateHumanHeight(data);
    });
});