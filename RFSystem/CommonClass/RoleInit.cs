using System.Windows.Forms;
using System.Data;
using System.Collections;

namespace RFSystem.CommonClass
{
    internal class RoleInit
    {
        private static TreeNode CheckedRolePoint(TreeView treeView, DataTable dtUserRoles, DataRow drUserRole)
        {
            if (!drUserRole["FatherRoleID"].ToString().Equals("TopPoint"))
            {
                TreeNode node = CheckedRolePoint(treeView, dtUserRoles, dtUserRoles.Select("RoleID='" + drUserRole["FatherRoleID"].ToString() + "'")[0]);
                node.Nodes[drUserRole["RoleID"].ToString()].Checked = true;
                return node.Nodes[drUserRole["RoleID"].ToString()];
            }

            treeView.Nodes[drUserRole["RoleID"].ToString()].Checked = true;

            return treeView.Nodes[drUserRole["RoleID"].ToString()];
        }

        public static void ClearNodesCheckState(TreeNodeCollection treeNodes)
        {
            foreach (TreeNode node in treeNodes)
            {
                node.Checked = false;

                if (node.Nodes != null)
                {
                    ClearNodesCheckState(node.Nodes);
                }
            }
        }

        public static void CreateMainMenu(MenuStrip menuStrip, DataTable dt)
        {
            DataRow[] rowArray = dt.Select("FatherRoleID='TopPoint'");

            foreach (DataRow row in rowArray)
            {
                ToolStripMenuItem topMenu = new ToolStripMenuItem
                {
                    Text = row["RoleName"].ToString()
                };

                CreateSubMenu(ref topMenu, row["RoleID"].ToString(), dt);
                menuStrip.Items.Add(topMenu);
            }
        }

        private static void CreateSubMenu(ref ToolStripMenuItem topMenu, string ItemID, DataTable dt)
        {
            DataView view = new DataView(dt)
            {
                RowFilter = "FatherRoleID='" + ItemID + "'"
            };

            for (int i = 0; i < view.Count; i++)
            {
                ToolStripMenuItem item = new ToolStripMenuItem
                {
                    Text = view[i]["RoleName"].ToString()
                };

                if (dt.Select("RoleID='" + ItemID + "'").Length != 0)
                {
                    CreateSubMenu(ref item, view[i]["RoleID"].ToString(), dt);
                }

                topMenu.DropDownItems.Add(item);
            }
        }

        private static void CreateSubNode(ref TreeNode topNode, string ItemID, DataTable dtTree)
        {
            DataView view = new DataView(dtTree)
            {
                RowFilter = "FatherRoleID='" + ItemID + "'"
            };

            for (int i = 0; i < view.Count; i++)
            {
                TreeNode node = new TreeNode
                {
                    Text = view[i]["RoleName"].ToString()
                };

                if (dtTree.Select("RoleID='" + ItemID + "'").Length != 0)
                {
                    CreateSubNode(ref node, view[i]["RoleID"].ToString(), dtTree);
                }

                node.Name = view[i]["RoleID"].ToString();
                node.Tag = view[i]["RoleID"].ToString();
                topNode.Nodes.Add(node);
            }
        }

        public static void CreateTreeView(TreeView treeView, DataTable dtTree)
        {
            DataRow[] rowArray = dtTree.Select("FatherRoleID='TopPoint'");

            foreach (DataRow row in rowArray)
            {
                TreeNode topNode = new TreeNode
                {
                    Text = row["RoleName"].ToString()
                };

                CreateSubNode(ref topNode, row["RoleID"].ToString(), dtTree);
                topNode.Name = row["RoleID"].ToString();
                topNode.Tag = row["RoleID"].ToString();
                treeView.Nodes.Add(topNode);
            }
        }

        public static ArrayList GetUserRolesID(TreeView treeView)
        {
            ArrayList userRolesList = new ArrayList();

            foreach (TreeNode node in treeView.Nodes)
            {
                if (node.Checked)
                {
                    userRolesList.Add(node.Tag);
                }

                if (node.Nodes.Count > 0)
                {
                    GetUserRolesNodeID(ref userRolesList, node);
                }
            }

            return userRolesList;
        }

        private static void GetUserRolesNodeID(ref ArrayList userRolesList, TreeNode fNode)
        {
            foreach (TreeNode node in fNode.Nodes)
            {
                if (node.Checked)
                {
                    userRolesList.Add(node.Tag);
                }

                if (node.Nodes.Count > 0)
                {
                    GetUserRolesNodeID(ref userRolesList, node);
                }
            }
        }

        public static void InitUserRoles(TreeView treeView, DataTable dtUserRoles)
        {
            ClearNodesCheckState(treeView.Nodes);

            foreach (DataRow row in dtUserRoles.Rows)
            {
                CheckedRolePoint(treeView, dtUserRoles, row);
            }
        }
    }
}
