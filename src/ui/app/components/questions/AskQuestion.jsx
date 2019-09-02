import React from 'react'
import { withFormik, Form, Field } from 'formik'
import * as Yup from 'yup'
const uuidv4 = require('uuid/v4')

import { postDummyQuestion } from '../../utils/apiCalls'

const AskQuestion = ({ errors, touched }) => (
    <Form>
        <h2>Ask Question</h2>
        <div>
            {touched.Title && errors.Title && <p className='tinWarning'>{errors.Title}</p>}
            <Field type='text' name='Title' placeholder='title' className='tinQuestionFormItem'/>
        </div>
        <div>
            {touched.Content && errors.Content && <p className='tinWarning'>{errors.Content}</p>}
            <Field component='textarea' name='Content' placeholder='content' className='tinQuestionFormItem'/>
        </div>
        <button type='submit'>Submit</button>
    </Form>
)

const CreateQuestion = withFormik({
    mapPropsToValues({ Title, Content }) {
        return {
            Title: Title || 'First Question about the programming',
            Content: Content || 'I dont know what I am doing'
        }
    },
    validationSchema: Yup.object().shape({
        Title: Yup.string().required().min(16).trim(),
        Content: Yup.string().required().min(10).trim()
    }),
    async handleSubmit(values) {
        values.Id = uuidv4()
        values.Date = new Date()
        console.log(values)
        postDummyQuestion(values)
    }
})(AskQuestion)

export default CreateQuestion