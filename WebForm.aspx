<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm.aspx.cs" Inherits="Application.WebForm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
           <table>
               <tr>
                   <td>Name:</td>
                   <td><asp:TextBox ID="txtname" runat="server"></asp:TextBox></td>
               </tr>
               <tr>
                   <td>Mobile:</td>
                   <td><asp:TextBox ID="txtmob" runat="server"></asp:TextBox></td>
               </tr>
               <tr>
                   <td>Gender:</td>
                   <td><asp:RadioButtonList ID="rblgender" runat="server" RepeatColumns="3"></asp:RadioButtonList></td>
               </tr>
               <tr>
                   <td>Hobbies:</td>
                   <td><asp:CheckBoxList ID="cblhobbies" runat="server" RepeatColumns="6"></asp:CheckBoxList></td>
               </tr>
               <tr>
                   <td></td>
                   <td><asp:Button ID="btnsubmit" runat="server" Text="Submit" OnClick="btnsubmit_Click" /></td>
               </tr>
               <tr>
                   <td></td>
                   <td><asp:GridView ID="gvform" runat="server" AutoGenerateColumns="false" OnRowCommand="gvform_RowCommand">
                       <Columns>
                           <asp:TemplateField HeaderText="User Id">
                               <ItemTemplate>
                                   <%#Eval("id") %>
                               </ItemTemplate>
                           </asp:TemplateField>
                           <asp:TemplateField HeaderText="User Name">
                               <ItemTemplate>
                                   <%#Eval("name") %>
                               </ItemTemplate>
                           </asp:TemplateField>
                           <asp:TemplateField HeaderText="User Mobile No">
                               <ItemTemplate>
                                   <%#Eval("mobile") %>
                               </ItemTemplate>
                           </asp:TemplateField>
                           <asp:TemplateField HeaderText="User Gender">
                               <ItemTemplate>
                                   <%#Eval("gender") %>
                               </ItemTemplate>
                           </asp:TemplateField>
                           <asp:TemplateField HeaderText="User Hobbies">
                               <ItemTemplate>
                                   <%#Eval("hobbies") %>
                               </ItemTemplate>
                           </asp:TemplateField>
                           <asp:TemplateField>
                               <ItemTemplate>
                                   <asp:Button ID="btndelete" runat="server" Text="Delete" CommandName="A" CommandArgument='<%#Eval("id") %>' />
                               </ItemTemplate>
                           </asp:TemplateField>
                           <asp:TemplateField>
                               <ItemTemplate>
                                   <asp:Button ID="btnedit" runat="server" Text="Edit" CommandName="B" CommandArgument='<%#Eval("id") %>' />
                               </ItemTemplate>
                           </asp:TemplateField>
                       </Columns>
                       </asp:GridView></td>
               </tr>
           </table> 
        </div>
    </form>
</body>
</html>
