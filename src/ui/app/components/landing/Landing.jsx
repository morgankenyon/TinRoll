import React from 'react'

class Landing extends React.Component {
    render() {
        return (
            <div id='tinLanding'>
                <h1>TinRoll</h1>
                <div id='tinAppGrid'>
                    <div id='tinAppFirst'>
                        <p>To-Do</p>
                        <ul>
                            <li>Questions</li>
                            <li>Answers</li>
                        </ul>
                    </div>
                    <div id='tinAppSecond'>A stack overflow clone</div>
                </div>
            </div>
        )
    }
}

export default Landing