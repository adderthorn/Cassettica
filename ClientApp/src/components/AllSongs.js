import React, { Component } from 'react'
import { FetchData } from './FetchData'

export class AllSongs extends Component {
    static displayName = AllSongs.name

    constructor(props) {
        super(props)
        this.state = { songs: [], loading: true }
    }

    componentDidMount() {
        this.populateSongData()
    }

    static renderSongsTable(songs) {
        return(
        <table className="table table-striped" aria-labelledby="tableLabel">
            <thead>
                <tr>
                    <th>Title</th>
                    <th>Artist</th>
                    <th>&nbsp;</th>
                </tr>
            </thead>
            <tbody>
                {songs.map(s =>
                    <tr key={s.guid}>
                        <td>{s.title}</td>
                        <td>{s.artist}</td>
                        <td>Play</td>
                    </tr>    
                )}
            </tbody>
        </table>
        )}

    render() {
        let contents = this.state.loading
            ? <p><em>Loading&hellip;</em></p>
            : AllSongs.renderSongsTable(this.state.songs)
        
        return (
            <div>
                <h1 id="tableLabel">All Songs</h1>
                {contents}
            </div>
        )
    }

    async populateSongData() {
        const response = await fetch('music/song')
        const data = await response.json()
        this.setState({ songs: data, loading: false })
    }
}