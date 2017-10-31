import { connect } from 'react-redux'
import { markToDoAsCompleted } from '../actions'
import ToDoList from '../components/ToDoList'

const getAllToDos = (todos) => {
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

const ToDoListContainer = connect(
  mapStateToProps,
  mapDispatchToProps
)(ToDoList)

export default ToDoListContainer