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
            <Field component='textarea' name='Content' placeholder='question' className='t-form-input' />
        </div>
        {/* <div id='tags' contentEditable="true" className='t-form-input' suppressContentEditableWarning={true}>Yes</div> */}
        <div>
            {/* <FieldArray name='Tags' className='t-form-input' render={arrayHelpers => (
                <div>
                    <Field type='text' name='yes' onKeyUp={(e) => {
                        if (e.keyCode === 13) {
                            arrayHelpers.push(e.target.value)
                        }
                    }} />
                    {values.Tags && values.Tags.length > 0 && (
                        values.Tags.map((Tag, index) => (
                            <div key={index}>
                                <Field name={`Tags.${index}`} />
                            </div>
                        ))
                    )}


                </div>
            )} /> */}
        </div>
        <button type='submit'>Submit</button>
    </Form>
)

const CreateInput = withFormik({
    mapPropsToValues({ Title, Content, TagIds, yes }) {
        return {
            Title: Title || 'A question about css',
            Content: Content || 'How does this whole float thing work out?',
            TagIds: TagIds || [1, 2, 3], //need to create tags
            yes: yes || ''
        }
    },
    validationSchema: Yup.object().shape({
        Title: Yup.string().required().min(16).trim(),
        Content: Yup.string().required().min(10).trim(),
        TagIds: Yup.array().required().min(1)
    }),
    async handleSubmit(values) {
        values.UserId = 1
        console.log(values)
        let status = await postObjectData('http://localhost:5000/api/questions', values)
    }
})(Input)

export default CreateInput