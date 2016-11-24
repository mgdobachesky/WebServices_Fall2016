<%@ Page Title="" Language="C#" MasterPageFile="~/FinalProject.Master" AutoEventWireup="true" CodeBehind="track.aspx.cs" Inherits="Dobachesky_FinalProject.track" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid">
        <div class="row">
            <div class="col-md-12">
                <ol class="breadcrumb">
                    <li><a href="/home">Home</a></li>
                    <li><a href="/artist">Artist</a></li>
                     <li><a href="/artist/album">Album</a></li>
                    <li class="active">Track</li>
                </ol>
            </div>
        </div>
        <div class="row">
            <div class="col-md-12 center">
                <h1 runat="server" id="lblArtist"></h1>
                <h3 runat="server" id="lblAlbum"></h3>
            </div>
        </div>
        <br />
        <br />
        <div class="row">
            <div class="col-md-12 center">
                <strong><p runat="server" id="lblTrack"></p></strong>
                <p runat="server" id="lblLyrics" class="lyrics"></p>
            </div>
        </div>
    </div>
</asp:Content>
