import { combineReducers } from 'redux'
import {
    ADD_TODO,
    UPDATE_TODO,
    MARK_TODO_AS_COMPLETED,
    DELETE_TODO,
    GET_ALL_TODOS
} from './actions'


function todos(state = [], action) {
  switch (action.type) {
    case ADD_TODO:
      return [
        ...state,
        {  
          text: action.payload,
          completed: null}
        
        
      ]
    case GET_ALL_TODOS:
      return [
        ...state,
        ...action.payload]
      
    case UPDATE_TODO:
      return [
        ...state,
        {

        }    
        ]
    case MARK_TODO_AS_COMPLETED:
      return [
        ...state,
        {
            
        }    
        ]
    case DELETE_TODO:
      return [
        ...state,
        {
    
        }    
        ]

      
    default:
      return state
  }
}

//incase we need more reducers besides for todo
const toDoApp = combineReducers({
  todos
})

export default toDoApp