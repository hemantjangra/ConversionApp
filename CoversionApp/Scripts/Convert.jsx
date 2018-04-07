var ConversionBox = React.createClass({

    getInitialState: function () {
        return {
            result: {}
        }
    },

    updateState(e) {
        e.preventDefault();
        var loadIcon = document.getElementById('loadingimage');
        var xhr = new XMLHttpRequest();
        var inputname = document.getElementById('inname').value;
        var inputamount = document.getElementById('inamount').value;

        xhr.open('POST', this.props.url, true);

        var params = JSON.stringify({ Name: inputname, Amount: inputamount });
        xhr.setRequestHeader("Content-type", "application/json; charset=utf-8");
        //xhr.setRequestHeader("Content-length", params.length);
        //xhr.setRequestHeader("Connection", "close");
        xhr.onload = function () {
            var response = JSON.parse(xhr.responseText);
            this.setState({ result: response.Data.outPut });

        }.bind(this);
        xhr.send(params);

    },

    render: function () {
        const { logo } = this.props;
        return (
            <div className="commentBox">
                <div class="row">
                    <p> Input Values</p>
                    <div class="col-sm-4">
                        <label for="inname">Choose a Name: </label>
                        <input id="inname" type="textbox" />
                    </div>
                    <div class="col-sm-8">
                        <label for="inamount">Choose Amount: </label>
                        <input id="inamount" type="textbox" />
                    </div>
                    <div class="col-sm-8">
                        <input class="active" id="convertBtn" type="button" value="Convert me to Alphabets" onClick={this.updateState} />
                    </div>
                </div>
                <div class="row">
                    <p> Output Values</p>
                    <div class="col-sm-4">
                        <label id="outName">Name: {this.state.result.Name}</label>
                    </div>
                    <div class="col-sm-8">
                        <label id="outamount">Converted Amount: {this.state.result.Amount}</label>
                    </div>
                </div>
            </div>
        );
    }
});
ReactDOM.render(
    <ConversionBox url="http://local.conversionapi.com/api/conversion/ConvertNumtoAlpha" />,
    document.getElementById('content')
);