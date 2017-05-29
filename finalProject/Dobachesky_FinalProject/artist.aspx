<%@ Page Title="" Language="C#" MasterPageFile="~/FinalProject.Master" AutoEventWireup="true" CodeBehind="artist.aspx.cs" Inherits="Dobachesky_FinalProject.artist" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid">
        <div class="row">
            <div class="col-md-12">
                <ol class="breadcrumb">
                    <li><a href="/home">Home</a></li>
                    <li class="active">Artist</li>
                </ol>
            </div>
        </div>
        <div class="row">
            <div class="col-md-4">
                <h1 runat="server" id="lblAlbums" class="center"></h1>
            </div>
        </div>
        <div class="row">
            <div class="col-md-4 center">
                <asp:Image ID="imgArtist" runat="server" Height="20em" />
            </div>
            <div class="col-md-6">
                <p runat="server" id="lblBio" class="artistBio"></p>
            </div>
        </div>
        <div class="row">
            <div class="col-md-12">
                <ul class="pager">
                    <li class="previous">
                        <asp:LinkButton ID="lbtnPrev" runat="server" onClick="previous_Click">Previous</asp:LinkButton>
                    </li>
                    <li class="next">
                        <asp:LinkButton ID="lbtnNext" runat="server" onClick="next_Click">Next</asp:LinkButton>
                    </li>
                </ul>
            </div>
        </div>
        <div class="row">
            <div class="col-md-12">
                <asp:Table ID="tblAlbums" runat="server" class="table table-hover">
                    <asp:TableHeaderRow>
                        <asp:TableHeaderCell>Album Name</asp:TableHeaderCell>
                        <asp:TableHeaderCell>Album Type</asp:TableHeaderCell>
                        <asp:TableHeaderCell>Release Date</asp:TableHeaderCell>
                    </asp:TableHeaderRow>
                </asp:Table>
            </div>
        </div>
    </div>
</asp:Content>
