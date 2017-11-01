import React from 'react'

const CurrentToDo = ({ item }) => (
  <li>
    <p>
      <label><b>Id:</b> </label> {item.Id}|
      <label>   <b>Title:</b> </label> {item.Title}|
      <label>   <b>Summary:</b> </label> {item.Summary}|
      <label>   <b>Date Completed:</b> </label> {item.DateCompleted}|
    </p>
  </li>
)

export default CurrentToDo