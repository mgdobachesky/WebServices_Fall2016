<%@ Page Title="" Language="C#" MasterPageFile="~/FinalProject.Master" AutoEventWireup="true" CodeBehind="album.aspx.cs" Inherits="Dobachesky_FinalProject.album" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid">
        <div class="row">
            <div class="col-md-12">
                <ol class="breadcrumb">
                    <li><a href="/home">Home</a></li>
                    <li><a href="/artist">Artist</a></li>
                    <li class="active">Album</li>
                </ol>
            </div>
        </div>
        <div class="row">
            <div class="col-md-12 center">
                <asp:Image ID="imgAlbum" runat="server" Height="20em" class="inline-block" />
                <div class="spacer inline-block"></div>
                <div class="inline-block">
                    <h1 runat="server" id="lblArtist" class="center"></h1>
                    <h3 runat="server" id="lblAlbum" class="center"></h3>
                </div>
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
                <asp:Table ID="tblTracks" runat="server" class="table table-hover">
                    <asp:TableHeaderRow>
                        <asp:TableHeaderCell>Track Name</asp:TableHeaderCell>
                        <asp:TableHeaderCell>Lyrics</asp:TableHeaderCell>
                        <asp:TableHeaderCell>Length</asp:TableHeaderCell>
                    </asp:TableHeaderRow>
                </asp:Table>
            </div>
        </div>
    </div>
</asp:Content>
