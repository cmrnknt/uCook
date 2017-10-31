import React from 'react'
import Footer from './components/Footer'
import AddToDo from './containers/AddToDo'
import ToDoListContainer from './containers/ListContainer'

const App = () => (
  <div>
    <AddToDo />
    <ToDoListContainer/>
    <Footer />
  </div>
)

export default App