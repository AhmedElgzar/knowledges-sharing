# Flux
Few words about flux,
It's a simple pub/sub arhitecture.
Consists of ___Stores___, ___Actions___, ___Dispatcher___, ___Views___

___Views___ - react components, listening for onChange event, get data from store, [example](https://github.com/facebook/flux/blob/master/examples/flux-todomvc/js/components/TodoApp.react.js)

___Actions___ - on user interactions(form submits - add, update) view calls ___Action___, which call ___Dispatcher___.

___Stores___ subscribed for dispatcher events. Store emits onChangeEvent.