//using tutorial: https://facebook.github.io/react/docs/tutorial.html
var ImageBox = React.createClass({
   render: function(){
       return (
        <div class="image-box">
            <img src={this.props.image.src} alt={this.props.image.name} />
        </div>
       );
   }
});

var App = React.createClass({
    render: function(){
        var images = this.props.data.map(function(image){
            return (
                <ImageBox image={image} />
            );
        });

        return (
            <div class="app">
                <h1>Animals</h1>
                <div class="image-list">
                    {images}
                </div>
            </div>
        );
    }
});
var data = [
    {"name": "Panda", "src": "img/panda.png"},
    {"name": "Koala", "src": "img/koala.png"}
];
React.render(
    <App data={data} />, document.getElementById('content')
);