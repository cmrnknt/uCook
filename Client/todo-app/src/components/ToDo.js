import React from 'react'

const ToDo = ({ onClick, item }) => (
  <li
    onClick={onClick}
  >
    <p>
      <label><b>Id:</b> </label> {item.Id}|
      <label>   <b>Title:</b> </label> {item.Title}|
      <label>   <b>Summary:</b> </label> {item.Summary}|
      <label>   <b>Date Completed:</b> </label> {item.DateCompleted}|
    </p>
  </li>
)

export default ToDo