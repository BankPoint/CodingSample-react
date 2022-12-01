import React, { Component } from 'react';

export class Home extends Component {
    static displayName = Home.name;

    render() {
        return (
            <div>
                <div style={{width:"600px", margin: "auto"} }>
                    <img
                        alt="background"
                        src="https://bankpointstaticfiles.z21.web.core.windows.net/images/BankPointHeaderConcepts03.jpg"
                        style={{width:"100%"} }
                    />
                    <hr />

                    Welcome, and thanks for your interest in BankPoint.
                    <br />
                    <br />
                    Please refer to the instructions <a href="https://github.com/BankPoint/programming-sample" target="_blank">found here</a> to begin.
                    <br />
                    <hr />
                </div>



            </div>
        );
    }
}
