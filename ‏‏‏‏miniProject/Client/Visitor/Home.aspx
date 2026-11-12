

<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="Visitor.Home" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<style>
  body {
    margin: 0;
    font-family: 'Segoe UI', Tahoma, Geneva, Verdana, sans-serif;
    background-color: #121212;
    color: #eee;
  }
  .hero {
    position: relative;
    width: 100%;
    max-width: 900px;
    margin: 40px auto 0 auto;
    border-radius: 12px;
    overflow: hidden;
    box-shadow: 0 8px 20px rgba(0,0,0,0.8);
  }
  .hero img {
    width: 100%;
    height: auto;
    display: block;
    filter: brightness(0.5);
    transition: filter 0.3s ease;
  }
  .hero:hover img {
    filter: brightness(0.7);
  }
  .hero-text {
    position: absolute;
    top: 50%;
    left: 50%;
    transform: translate(-50%, -50%);
    color: #fff;
    text-align: center;
    padding: 0 20px;
  }
  .hero-text h1 {
    font-size: 3rem;
    margin: 0 0 10px;
    text-shadow: 2px 2px 6px rgba(0,0,0,0.7);
  }
  .hero-text p {
    font-size: 1.25rem;
    letter-spacing: 1px;
    text-shadow: 1px 1px 4px rgba(0,0,0,0.6);
  }
  section.intro {
    max-width: 700px;
    margin: 40px auto;
    padding: 20px;
    background: #222;
    border-radius: 10px;
    box-shadow: 0 6px 15px rgba(0,0,0,0.7);
    text-align: center;
  }
  section.intro h2 {
    font-size: 2rem;
    margin-bottom: 15px;
    color: #f0c040; /* subtle gold accent */
  }
  section.intro p {
    font-size: 1.1rem;
    line-height: 1.6;
    color: #ddd;
  }
  @media (max-width: 640px) {
    .hero-text h1 {
      font-size: 2rem;
    }
    .hero-text p {
      font-size: 1rem;
    }
    section.intro {
      margin: 20px 15px;
      padding: 15px;
    }
    section.intro h2 {
      font-size: 1.5rem;
    }
  }
</style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<div class="hero">
  <img src="images/company.jpg" alt="Mercedes-Benz company" />
  <div class="hero-text">
    <h1>Welcome to the Mercedes-Benz Store</h1>
    <p>Your destination for luxury performance vehicles.</p>
  </div>
</div>

<section class="intro">
  <h2>Discover Excellence</h2>
  <p>Explore our collection of the latest Mercedes-Benz models and exclusive offers.</p>
</section>

</asp:Content>
