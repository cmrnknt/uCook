import React, { Component } from 'react'
import axios from 'axios'
import { connect } from 'react-redux'
import { Link, browserHistory } from 'react-router'

import ToDoList from '../components/ToDoList'
import { markToDoAsCompleted, addToDo, getAllToDos } from '../actions'

class ToDoListContainer extends Component {
  componentWillMount() {
    let self = this
    
    axios.get('http://localhost:52554/api/todo')
    .then(function (response) {
      let data = response && response.data //&& is for if not null
      console.log(data)
      self.props.dispatch(getAllToDos(data))
    }) 
    .catch(function (error) {
        console.log(error);
    });
  }

  render() {
    const { todos, onToDoClick } = this.props
    return (
      <div>
        <ToDoList todos={todos} onToDoClick={onToDoClick} />
      </div>
    )
  }
}

const mapStateToProps = state => {
  return {
    todos: state && state.todos
  }
}

const mapDispatchToProps = dispatch => {
  return {
    onToDoClick: id => {
      dispatch(markToDoAsCompleted(id))
    }
  }
}

export default connect(mapStateToProps, mapDispatchToProps)(ToDoListContainer)