
var offersUi = 'offers-content';


class Offers extends React.Component {
    /*constructor(props) {
        super(props);
        this.state = {
            data: []
        };
    }

    componentDidMount() {
        this.GetOffers();
    }

    GetOffers() {
        axios.get(this.props.url)
            .then(results => {
                var obj = results.data.tests.map(group => group);
                this.setState({ data: obj });
            })
            .catch(err => {
                console.warn(err);
            });
    }*/

    render() {
        console.info("Passing: ", this.state.data);
        return (
            <div>
                <h3>Offers</h3>
                <hr />
                <form method="post" id="offerForm">
                    <input type="hidden" asp-for="Input.Offer.Id"/>
                    <div class="form-group">
                        <label asp-for="Input.Offer.Title"></label>
                        <input asp-for="Input.Offer.Title" class="form-control" />
                    </div>
                    <div class="form-group">
                        <label asp-for="Input.Offer.Description"></label>
                        <input asp-for="Input.Offer.Description" class="form-control" />
                        <span asp-validation-for="Input.Offer.Description" class="text-danger"></span>
                    </div>
                    {/* <!--<div class="form-group">
                        <label asp-for="Input.Offer.Track"></label>
                        { <select asp-for="Input.Offer.Track">
                            @foreach(var track in Model.Tracks)
                            {
                                <option value="@track.Id">@track.Name</option>
                            }
                        </select>
                        <span asp-validation-for="Input.Offer.Track" class="text-danger"></span>
                    </div>
                    @Html.Partial("_credits", Model.Credit) }--> */}


                    <div class="form-group">
                        <label asp-for="Input.Offer.Ends"></label>
                        <input type="date" asp-for="Input.Offer.Ends" class="form-control" />
                        <span asp-validation-for="Input.Offer.Ends" class="text-danger"></span>
                    </div>
                    <button type="submit" class="button small">Save</button>
                </form>
            </div>
        )
    }
}


class App extends React.Component {
    render() {
        return (
            <div>
                <h3>Offers?</h3>
            </div>
            // <Offers url="http://localhost:62376/api/report" />
        );
    }
}




ReactDOM.render(<App />, document.getElementById(offersUi));


