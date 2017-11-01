export const ADD_TODO = 'ADD_TODO'
export const MARK_TODO_AS_COMPLETED = 'MARK_TODO_AS_COMPLETED'
export const UPDATE_TODO = 'UPDATE_TODO'
export const DELETE_TODO = 'DELETE_TODO'
export const GET_ALL_TODOS = 'GET_ALL_TODOS'

export function addToDo(values) {
  return { type: ADD_TODO, payload: values}
}

export function markToDoAsCompleted(index){
    return {type: MARK_TODO_AS_COMPLETED, payload: index}
}

export function updateToDo({todo}) {
  return { type: UPDATE_TODO, payload: todo }
}

export function deleteToDo(index) {
    return { type: DELETE_TODO, payload: index }
} 

export function getAllToDos(list) {
    return { type: GET_ALL_TODOS, payload: list }
}
