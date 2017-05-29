<%@ Page Title="" Language="C#" MasterPageFile="~/FinalProject.Master" AutoEventWireup="true" CodeBehind="genres.aspx.cs" Inherits="Dobachesky_FinalProject.genres" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid">
        <div class="row">
            <div class="col-md-12">
                <ol class="breadcrumb">
                    <li class="active">Genres</li>
                </ol>
            </div>
        </div>
        <div class="row">
            <div class="col-md-12">
                <h1 runat="server" class="center">Genres</h1>
            </div>
        </div>
        <div class="row">
            <div class="col-md-12">
                <div class="list-group">
                    <asp:LinkButton ID="lbtnAlternative" runat="server" OnCommand="lbtn_Click" CommandArgument="20,Alternative" CssClass="list-group-item">Alternative</asp:LinkButton>
                    <asp:LinkButton ID="lbtnAnime" runat="server" OnCommand="lbtn_Click" CommandArgument="29,Anime" CssClass="list-group-item">Anime</asp:LinkButton>
                    <asp:LinkButton ID="lbtnBlues" runat="server" OnCommand="lbtn_Click" CommandArgument="2,Blues" CssClass="list-group-item">Blues</asp:LinkButton>
                    <asp:LinkButton ID="lbtnChildrensMusic" runat="server" OnCommand="lbtn_Click" CommandArgument="4,Childrens Music" CssClass="list-group-item">Childrens Music</asp:LinkButton>
                    <asp:LinkButton ID="lbtnChristianGospel" runat="server" OnCommand="lbtn_Click" CommandArgument="22,Christian-Gospel" CssClass="list-group-item">Christian-Gospel</asp:LinkButton>
                    <asp:LinkButton ID="lbtnClassical" runat="server" OnCommand="lbtn_Click" CommandArgument="5,Classical" CssClass="list-group-item">Classical</asp:LinkButton>
                    <asp:LinkButton ID="lbtnComedy" runat="server" OnCommand="lbtn_Click" CommandArgument="3,Comedy" CssClass="list-group-item">Comedy</asp:LinkButton>
                    <asp:LinkButton ID="lbtnCountry" runat="server" OnCommand="lbtn_Click" CommandArgument="6,Country" CssClass="list-group-item">Country</asp:LinkButton>
                    <asp:LinkButton ID="lbtnDance" runat="server" OnCommand="lbtn_Click" CommandArgument="17,Dance" CssClass="list-group-item">Dance</asp:LinkButton>
                    <asp:LinkButton ID="lbtnEasyListening" runat="server" OnCommand="lbtn_Click" CommandArgument="25,Easy Listening" CssClass="list-group-item">Easy Listening</asp:LinkButton>
                    <asp:LinkButton ID="lbtnElectronic" runat="server" OnCommand="lbtn_Click" CommandArgument="7,Electronic" CssClass="list-group-item">Electronic</asp:LinkButton>
                    <asp:LinkButton ID="lbtnHipHopRap" runat="server" OnCommand="lbtn_Click" CommandArgument="18,Hip Hop/Rap" CssClass="list-group-item">Hip Hop/Rap</asp:LinkButton>
                    <asp:LinkButton ID="lbtnHoliday" runat="server" OnCommand="lbtn_Click" CommandArgument="8,Holiday" CssClass="list-group-item">Holiday</asp:LinkButton>
                    <asp:LinkButton ID="lbtnJPop" runat="server" OnCommand="lbtn_Click" CommandArgument="27,J-Pop" CssClass="list-group-item">J-Pop</asp:LinkButton>
                    <asp:LinkButton ID="lbtnJazz" runat="server" OnCommand="lbtn_Click" CommandArgument="11,Jazz" CssClass="list-group-item">Jazz</asp:LinkButton>
                    <asp:LinkButton ID="lbtnLatinUrban" runat="server" OnCommand="lbtn_Click" CommandArgument="12,Latin" CssClass="list-group-item">Latin</asp:LinkButton>
                    <asp:LinkButton ID="lbtnNewAge" runat="server" OnCommand="lbtn_Click" CommandArgument="13,New Age" CssClass="list-group-item">New Age</asp:LinkButton>
                    <asp:LinkButton ID="lbtnOpera" runat="server" OnCommand="lbtn_Click" CommandArgument="9,Opera" CssClass="list-group-item">Opera</asp:LinkButton>
                    <asp:LinkButton ID="lbtnPop" runat="server" OnCommand="lbtn_Click" CommandArgument="14,Pop" CssClass="list-group-item">Pop</asp:LinkButton>
                    <asp:LinkButton ID="lbtnRBSoul" runat="server" OnCommand="lbtn_Click" CommandArgument="15,R&B/Soul" CssClass="list-group-item">R&B/Soul</asp:LinkButton>
                    <asp:LinkButton ID="lbtnReggae" runat="server" OnCommand="lbtn_Click" CommandArgument="24,Reggae" CssClass="list-group-item">Reggae</asp:LinkButton>
                    <asp:LinkButton ID="lbtnRock" runat="server" OnCommand="lbtn_Click" CommandArgument="21,Rock" CssClass="list-group-item">Rock</asp:LinkButton>
                    <asp:LinkButton ID="lbtnSingerSongwriter" runat="server" OnCommand="lbtn_Click" CommandArgument="10,Singer/Songwriter" CssClass="list-group-item">Singer/Songwriter</asp:LinkButton>
                    <asp:LinkButton ID="lbtnSoundtrack" runat="server" OnCommand="lbtn_Click" CommandArgument="16,Soundtrack" CssClass="list-group-item">Soundtrack</asp:LinkButton>
                    <asp:LinkButton ID="lbtnVocal" runat="server" OnCommand="lbtn_Click" CommandArgument="23,Vocal" CssClass="list-group-item">Vocal</asp:LinkButton>
                    <asp:LinkButton ID="lbtnWorld" runat="server" OnCommand="lbtn_Click" CommandArgument="19,World" CssClass="list-group-item">World</asp:LinkButton>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
