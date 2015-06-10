//using tutorial: https://facebook.github.io/react/docs/tutorial.html
var ImageBox = React.createClass({
    handleRemoveClick: function(e){
        e.preventDefault();
        this.props.removeImage(this.props.image);
    },
   render: function(){
       return (
        <div class="image-box">
            <img src={this.props.image.src} alt={this.props.image.name} />
            <p><a href="#" onClick={this.handleRemoveClick}>Remove</a></p>
        </div>
       );
   }
});

var ImageForm = React.createClass({
    handleSubmit: function(e){
        e.preventDefault();
        var name = React.findDOMNode(this.refs.name).value;
        var src = React.findDOMNode(this.refs.src).value;
        this.props.addImage({name: name, src: src});
        React.findDOMNode(this.refs.name).value = '';
    },
    render: function(){
        return (
            <div class="form-wrap">
                <form onSubmit={this.handleSubmit}>
                    <p>
                        <input type="text" placeholder="name" ref="name"/>
                        <select ref="src">
                            <option value="img/koala.png">Koala</option>
                            <option value="img/panda.png">Panda</option>
                        </select>
                        <input type="submit" value="Add Image"/>
                    </p>
                </form>
            </div>
        );
    }
});

var App = React.createClass({
    //handlers
    removeImage: function(image){
        this.state.data.splice(this.state.data.indexOf(image), 1);
        this.setState({data: this.state.data});
    },
    addImage: function(image){
        this.state.data.push(image);
        this.setState({data: this.state.data});
    },

    //runs once per lifetime and setup initial state
    getInitialState: function(){
        return { data: [] };
    },
    //runs when component is rendered
    componentDidMount: function(){
        //NOTE: we can use bind to remove ugly $this = this;
        var $this = this;
        var loadData = function(){
            $.getJSON('data.json', function(data){
                $this.setState({data: data});
            });
        }
        loadData();
        //state is reactive
        /*setInterval(function(){
            loadData();
        }, 3000);*/

    },
    render: function(){
        var $this = this;
        /*
        * Note props is immutable
        * */
        //var images = this.props.data.map(function(image){
        var images = this.state.data.map(function(image){
            return (
                <div class="image-list">
                    <ImageBox image={image} removeImage={$this.removeImage} />
                    <hr />
                </div>
            );
        });

        return (
            <div class="app">
                <h1>Animals</h1>
                <ImageForm addImage={this.addImage} />
                {images}
            </div>
        );
    }
});

React.render(
    <App />, document.getElementById('content')
);