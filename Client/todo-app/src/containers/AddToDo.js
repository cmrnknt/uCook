import React, { Component } from 'react'
import { connect } from 'react-redux'
import axios from 'axios'

import { addToDo, getAllToDos } from '../actions'

class AddToDo extends Component {

  submitForm(values) {
      console.log(JSON.stringify( values))
    axios.post('http://localhost:52554/api/todo', JSON.stringify(values)) //UPDATE URL
    .then(function(response) {
        let data = response && response.data //&& is for if not null
        this.props.dispatch(addToDo(data))
    }) 
    .catch(function (error) {
        console.log(error);
    });
  }

    render() {
        let { dispatch } = this.props
        let title
        let summary

        return (
            <div> 
                <form
                    onSubmit={e => {
                        e.preventDefault()
                        this.submitForm({title: title.value, summary: summary.value})
                        title.value = ''
                        summary.value = ''
                    }}
                >
                Title: <input
                    ref={value => {
                        title = value
                    }}
                />
                Summary: <input
                    ref={value => {
                        summary = value
                    }}
                />
                <button type="submit">
                    Add ToDo
                </button>
                </form>
            </div>
        )
    }

}

const mapDispatchToProps = (dispatch, ownProps) => {
    return {
        dispatch
    }
  }

AddToDo = connect(null, mapDispatchToProps)(AddToDo)

export default  AddToDo 