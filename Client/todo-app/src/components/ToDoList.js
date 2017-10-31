import React from 'react'
import ToDo from './ToDo'


const ToDoList = ({ todos, onToDoClick }) => (
  <ul>
    {todos.map((todo, index) => (
      <ToDo key={index} item={JSON.parse(todo)} onClick={() => onToDoClick(index)} />
    ))}
  </ul>
)

const mapStateToProps = state => {
  return {
    todos: state && state.todos
  }
}

const mapDispatchToProps = dispatch => {
  return {
    onToDoClick: id => {
      console.log(id)
    }
  }
}

export default ToDoList