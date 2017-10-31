import React, { Component } from 'react'
import { connect } from 'react-redux'
import { addToDo, getAllToDos } from '../actions'
import axios from 'axios'

class AddToDo extends Component {
    
    
componentWillMount() {
    let self = this
    axios.get('http://localhost:52554/api/todo')
         .then(function (response) {
            let data = response && response.data //&& is for if not null
            self.props.dispatch(getAllToDos(data))
        }) 
        .catch(function (error) {
            console.log(error);
        });
  }

    render() {
        let { dispatch } = this.props
        let input

        return (
            <div> 
                <form
                onSubmit={e => {
                    e.preventDefault()
                    if (!input.value.trim()) {
                    return
                    }
                    dispatch(addToDo(input.value))
                    input.value = ''
                }}
                >
                <input
                    ref={node => {
                    input = node
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

export default AddToDo