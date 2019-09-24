import React from 'react'

import './input.css'

import { postObjectData } from '../../utils/apiCalls'
import { withFormik, Form, Field, FieldArray } from 'formik'
import * as Yup from 'yup'

const Input = ({ errors, touched, values }) => (
    <Form className='t-form'>
        <div>
            {touched.Title && errors.Title && <p className='tin-warning'>{errors.Title}</p>}
            <Field type='text' name='Title' placeholder='title' className='t-form-input' />
        </div>
        <div>
            {touched.Content && errors.Content && <p className='tin-warning'>{errors.Content}</p>}
            <Field component='textarea' name='Content' placeholder='question' className='t-form-input'/>
        </div>
        {/* <div id='tags' contentEditable="true" className='t-form-input' suppressContentEditableWarning={true}>Yes</div> */}
        <div>
            <FieldArray name='Tags' className='t-form-input' render={arrayHelpers => (
                <div>
                    <Field type='text' name='yes' onKeyUp={(e) => {
                            if(e.keyCode === 13) {
                                arrayHelpers.push(e.target.value)
                            }
                        }}/>
                    {values.Tags && values.Tags.length > 0 && (
                        values.Tags.map((Tag, index) => (
                            <div key={index}>
                                <Field name={`Tags.${index}` } />
                                {/* <button
                                    type="button"
                                    onClick={() => arrayHelpers.remove(index)} // remove a friend from the list
                                >
                                    -
                                </button>
                                <button
                                    type="button"
                                    onClick={() => arrayHelpers.insert(index, '')} // insert an empty string at a position
                                >
                                    +
                                </button> */}
                            </div>
                            ))
                            )}
                    
                    
                </div>
            )} />
        </div>
        <button type='submit'>Submit</button>
    </Form>
)

const CreateInput = withFormik({
    mapPropsToValues({ Title, Content, Tags, yes }) {
        return {
            Title: Title || 'A question about css',
            Content: Content || 'How does this whole float thing work out?',
            Tags: Tags || [''],
            yes: yes || ''
        }
    },
    validationSchema: Yup.object().shape({
        Title: Yup.string().required().min(16).trim(),
        Content: Yup.string().required().min(10).trim(),
        Tags: Yup.array().required().min(1)
    }),
    async handleSubmit(values) {
        values.UserId = 1
        console.log(values)
        // let status = await postObjectData('http://localhost:1076/api/questions', values)
        // console.log(status) 
    }
})(Input)

export default CreateInput

// export default class Input extends React.Component {
//     constructor(props) {
//         super(props)

//         this.state = {
//             title:'Second Question',
//             content:'We are trying to make this work',
//             tags:[]
//         }
//         this.handleSubmit = this.handleSubmit.bind(this)
//         this.handleChange = this.handleChange.bind(this)
//     }

//     async handleSubmit(e) {
//         e.preventDefault()
//         let data = {
//             Title:this.state.title,
//             Content:this.state.content,
//             UserId:1
//         }
//         console.log(data)
//         let status = await postObjectData('http://localhost:1076/api/questions', data)
//         console.log(status) 
//     }

//     handleChange(e) {
//         let target = e.target.name
//         this.setState({
//             [target]:e.target.value
//         })

//     }
//     render() {
//         return ( 
//             <div className='tin-input'>
//                 {this.props.children}
//                 <form onSubmit={this.handleSubmit} className='t-form'>
//                     <input 
//                         type='text' 
//                         name='title' 
//                         placeholder='title' 
//                         className='t-form-element' 
//                         value={this.state.title} 
//                         onChange={this.handleChange} 
//                     />
//                     <textarea 
//                         name='content' 
//                         placeholder='question'  
//                         className='t-form-element' 
//                         value={this.state.content} 
//                         onChange={this.handleChange} 
//                     />
//                     <input type='submit' value='Ask'/>
//                 </form>
//             </div>
//         )
//     }
// }