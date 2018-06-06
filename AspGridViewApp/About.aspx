<%@ Page Title="About" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeFile="About.aspx.cs" Inherits="About" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <hgroup class="title">
        
        <h2>Sample grid showing frozen header</h2>
    </hgroup>    

    <div>
      
        <asp:GridView ID="GridView1" runat="server" Width="100%" 
            AutoGenerateColumns="false" GridLines="None" AllowPaging="true" PageSize="20"
            OnPageIndexChanging="GridView1_PageIndexChanging" AllowSorting="true"> 
            <Columns> 
                <asp:BoundField HeaderText="ID" DataField="ID" /> 
                <asp:BoundField HeaderText="Name" DataField="Name" /> 
                <asp:BoundField HeaderText="Place" DataField="Place" />                
            </Columns> 
            <HeaderStyle CssClass="GridviewScrollHeader" /> 
            <RowStyle CssClass="GridviewScrollItem" /> 
            <PagerStyle CssClass="GridviewScrollPager" /> 
        </asp:GridView> 

    </div>

    
    <script type="text/javascript"> 

        var gridViewScroll = null;
        window.onload = function () {
            gridViewScroll = new GridViewScroll({
                elementID: "MainContent_GridView1",
                width: 850,
                height: 350,
                freezeColumn: true,
                //freezeFooter: true,
                freezeColumnCssClass: "GridViewScrollItemFreeze",
                freezeFooterCssClass: "GridViewScrollFooterFreeze",
                freezeHeaderRowCount: 1,
                freezeColumnCount: 0,
                onscroll: function (scrollTop, scrollLeft) {
                    //console.log(scrollTop + " - " + scrollLeft);
                }
            });
            gridViewScroll.enhance();
        }       

    </script>
   
</asp:Content>