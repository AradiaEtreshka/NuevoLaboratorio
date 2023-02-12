<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ActividadView.aspx.cs" Inherits="NuevoLaboratorio.vistas.ActividadView" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Actividades</title>
    <link href="../css/loginSignupStyles.css" rel="stylesheet" />
    <style type="text/css">
        .auto-style1 {
            display: block;
            font-size: 1rem;
            font-weight: 400;
            line-height: 1.5;
            color: #212529;
            background-clip: padding-box;
            -webkit-appearance: none;
            -moz-appearance: none;
            appearance: none;
            border-radius: .375rem;
            transition: none;
            border: 1px solid #ced4da;
            background-color: #fff;
        }
    </style>
</head>
<body>
    <header class="container">
    <nav>
      <h1 style="color:aliceblue" >Laboratorio</h1>

      <div class="user-info">
        <div class="user-image"></div>
        
      </div>
    </nav>
  </header>
    <script src="../assets/pluggins/dist/sweetalert2.all.js"></script>
    <form id="form1" runat="server">
        <div>
      <asp:Button ID="nueva_Actividad" runat="server" CssClass="fa-solid fa-pencil" Text="Nueva Actividad" OnClick="nueva_Actividad_Click"  />
      <asp:Button ID="volver" runat="server" CssClass="fa-solid fa-pencil" OnClick="volver_Click" Text="Volver" />
      </div>
    <asp:Panel runat="server" ID="PNL_NuevaActividad" Visible="false" >
        
        <div class="jumbotron" style= " background-position: center; opacity: 0,1; background-color: black; "
            height: 100vh >
            <h3 style=" border-color: #000000; color: white"> <asp:Label ID="Label1" runat="server" Text="Nueva Actividad" Font-Bold="true" Font-Italic="true"></asp:Label>
            </h3>
            <asp:HiddenField ID="HF_ModificarActividad" runat="server" />
            <asp:HiddenField ID="HF_IdProtocol" runat="server" />

            <div class="form-group">
               
                <label style=" color: white; font-weight: bold; font-size: large;" >Descripcion</label>
                 
                <asp:TextBox runat="server" ID="TB_Descripcion" CssClass="form-control" Width="203px"></asp:TextBox>

                <br />

                <br />
                <asp:CheckBox ID="Finalizada" runat="server" Text="Actividad Finalizada?" ForeColor="White"/>
                <br />
                <br />
                <asp:Label Text= "Puntaje" runat="server" ForeColor="White"/>
                <asp:TextBox ID="TB_Puntaje" runat="server" ></asp:TextBox>
                <br />
                <br />
             

            </div>
            <asp:Button Text="Guardar Actividad" ID="BTN_Guardar" runat="server" CssClass="btn btn-info"  Visible ="true" OnClick="BTN_Guardar_Click"  />
            <asp:Button Text="Cancelar" ID="BTN_Cancelar" runat="server" CssClass="btn btn-default" Visible="true" OnClick="BTN_Cancelar_Click" />

        </div>
    </asp:Panel>

        <div class="row">

        <asp:GridView ID="GV_Actividades" runat="server" OnRowCommand="GV_Actividades_RowCommand"
            AutoGenerateColumns="false"
            CellPadding="4" ForeColor="Black" GridLines="Horizontal" Width="100%"
            BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" EmptyDataText="Sin Registros" >

            <FooterStyle BackColor="#CCCC99" ForeColor="Black"></FooterStyle>

            <HeaderStyle BackColor="#333333" Font-Bold="True" ForeColor="White"></HeaderStyle>

            <PagerStyle HorizontalAlign="Right" BackColor="White" ForeColor="Black"></PagerStyle>

            <SelectedRowStyle BackColor="#CC3333" Font-Bold="True" ForeColor="White"></SelectedRowStyle>

            <SortedAscendingCellStyle BackColor="#F7F7F7"></SortedAscendingCellStyle>

            <SortedAscendingHeaderStyle BackColor="#4B4B4B"></SortedAscendingHeaderStyle>

            <SortedDescendingCellStyle BackColor="#E5E5E5"></SortedDescendingCellStyle>

            <SortedDescendingHeaderStyle BackColor="#242121"></SortedDescendingHeaderStyle>
            <Columns>
                
                <asp:TemplateField HeaderText="Descripcion">
                    <ItemTemplate>
                        <%# Eval("Descripcion")%>
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Puntaje">
                    <ItemTemplate>
                        <%# Eval("Puntaje")%>
                    </ItemTemplate>
                </asp:TemplateField>
     
                <asp:TemplateField>
                    <ItemTemplate>
                  
                        <asp:LinkButton Text="Modificar" ID="BTN_Modificar" runat="server" CssClass="btn btn-warning"
                            CommandName="Modificar" CommandArgument='<%#Eval("Id") %>' ></asp:LinkButton>
                        
                    </ItemTemplate>
                </asp:TemplateField>            
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:LinkButton Text="Eliminar" ID="BTN_Eliminar" runat="server" CssClass="btn btn-danger"
                            CommandName="Eliminar" CommandArgument='<%#Eval("Id") %>' Visible="true" ></asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:LinkButton Text="Puntuar" ID="BTN_Puntuar" runat="server" CssClass="btn btn-danger"
                            CommandName="Puntuar" CommandArgument='<%#Eval("Id") %>' Visible="true" ></asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>



                               
                
            </Columns>
        </asp:GridView>
   </div>
    </form>
</body>
</html>
