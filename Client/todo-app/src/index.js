import React from 'react';
import ReactDOM from 'react-dom';
import { routerReducer, routerMiddleware, push } from 'react-router-redux'
import { Provider } from 'react-redux';
import { Route, Router} from 'react-router'
import logger from 'redux-logger';
import { createStore, applyMiddleware, compose, combineReducers} from 'redux';
import createHistory from 'history/createBrowserHistory'

import reducers from './reducers';
import registerServiceWorker from './registerServiceWorker';

import AddToDo from './containers/AddToDo';
import ToDoListContainer from './containers/ListContainer';


import './index.css';

const history = createHistory()

const middleware = routerMiddleware(history)

export const store = createStore(
    combineReducers({
        ...reducers,
        router: routerReducer
      }),     
    compose(        
        applyMiddleware(middleware),
        applyMiddleware(logger)
    )
)

ReactDOM.render(
    <Provider store={store}>
    <Router history={history}>
      <div>
        <Route exact path="/" component={ToDoListContainer}/>
        <Route exact path="/add" component={AddToDo}/>
      </div>
    </Router>
    </Provider>, 
    document.getElementById('root')
);
registerServiceWorker();
